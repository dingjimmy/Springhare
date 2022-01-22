// Copyright (c) James C Dingle. All rights reserved.

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Springhare.Actions.Poc.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        // GET: api/<SessionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SessionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SessionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SessionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SessionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
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
 *  2.2 Check invokation complete: [GET] api/session/{id}/invokation{id}
 *    - If invokation still active, check again later. 
 *
 *  2.3 When invokation completes, retrieve any data: [GET] api/session/{id}/invokation/{id}/data
 *  
 *  2.4 When need to prematurly terminate an invokation: [DELETE] api/session/{id}/invokation/{id}
 *  
 *  2.4 Continue invoking until session no longer needed. Handle failed invokations when they occur.
 *  
 *  3. Destroy session: [DELETE] api/session/{id}
 *     - Stop any active invokations
 *     - Clean-up resources
 * 
 */