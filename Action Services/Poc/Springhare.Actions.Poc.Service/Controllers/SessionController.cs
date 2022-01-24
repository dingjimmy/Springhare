// Copyright (c) James C Dingle. All rights reserved.

using Microsoft.AspNetCore.Mvc;
using Springhare.Actions.Poc.Service.Model;
using System.Collections.Concurrent;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Springhare.Actions.Poc.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ConcurrentDictionary<Guid, Session> _Sessions = new ConcurrentDictionary<Guid, Session>();

        // GET: api/<SessionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<SessionController>
        [HttpPost]
        public void Post([FromBody] CreateSessionRequest request)
        {
            var sessionID = Guid.NewGuid();
            var action = new PocAction(request.Configuration, new PocActionState());
            _Sessions.TryAdd(new Session(sessionID, action));
        }

        // DELETE api/<SessionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

public class PocAction : ActionBase<PocActionConfiguration, PocActionState, PocActionData>
{
    public PocAction(PocActionConfiguration configuration, PocActionState startingState) : base(configuration, startingState)
    {
    }

    public override Result Setup()
    {
        return base.Setup();
    }

    public override Result<PocActionData?> Invoke()
    {
        return base.Invoke();
    }

    public override Result Teardown()
    {
        return base.Teardown();
    }
}

public class CreateSessionRequest
{
    public PocActionConfiguration Configuration { get; set; } = new PocActionConfiguration();
}

public class PocActionData
{
}

public class PocActionState
{
}

public class PocActionConfiguration
{
}

/*
 * # MODEL
 * 
 *   Session: an instance of an action, that represets multiple related invokations of it.
 *   Invokation: a single execution of the action; takes an input, processess and provides an output.
 *   
 * 
 * # SEQUENCE
 * 
 *  1. Create session: [POST] api/session
 *     - create and setup a session using provided configuration, so that it is ready to run
 *     
 *  2.1 Invoke session: [POST] api/session/{id}/invokation
 *    - invoke the action, using provided input & saving any outputs
 *    
 *  2.2 Check invokation complete: [GET] api/session/{id}/invokation/{id}
 *    - If invokation still active, check again later. 
 *
 *  2.3 When invokation completes, retrieve any data: [GET] api/session/{id}/invokation/{id}/data
 *  
 *  2.4 If need to prematurly terminate an invokation: [DELETE] api/session/{id}/invokation/{id}
 *  
 *  2.4 Continue invoking until session no longer needed. Handle failed invokations when they occur.
 *  
 *  3. Destroy session: [DELETE] api/session/{id}
 *     - Stop any active invokations
 *     - Clean-up resources
 * 
 */