using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Springhare.Activities.Abstractions;

namespace Springhare.Activities.LongRunningActivity.Controllers
{
    [ApiController]
    [Route("lra]")]
    public class LongRunningActivityController : ControllerBase
    {
        private readonly ILogger<LongRunningActivityController> _logger;
        private readonly IDictionary<Guid, Session> _sessions;

        public LongRunningActivityController(ILogger<LongRunningActivityController> logger)
        {
            _logger = logger;
        }

        [HttpPost("sessions")]
        public IActionResult Setup(IActivityConfiguration configuration)
        {
            var session = new Session();
            session.Activity.Configuration = configuration;
            session.Activity.Setup();

            _sessions.Add(session.Id, session);

            return Created($"session/{session.Id}","");
        }

        [HttpDelete("session/{id}")]
        public IActionResult Teardown(Guid id)
        {
            _sessions[id].Activity.Teardown();
            
            _sessions.Remove(id);

            return Ok();
        }

        [HttpGet("session/{id}")]
        public Session Get(Guid id)
        {
            return _sessions[id];
        }

        [HttpPost("session/{id}/pulses")]
        public IActionResult Pulse(Guid id)
        {
            var session = _sessions[id];

            var pulse = new Pulse()
            {
                Number = session.Pulses.Count + 1
            };

            session.Pulses.Add(pulse.Number, pulse) ;

            
            pulse.Result = session.Activity.Execute();

            return Ok();
        }

    }


    public class Session
    {
        public Guid Id { get; set; }
        public LongRunningActivity Activity { get; set; }
        public Dictionary<long, Pulse> Pulses { get; set; }
    }

    public class Pulse
    {
        public long Number { get; set; }    

        public object Data { get; set; }

        public ActivityResult Result { get; set; }
    }
}
