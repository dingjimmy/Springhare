using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Springhare.Workflow
{
    public class Step
    {
        private readonly HttpClient _httpClient;

        public string Name { get; set; }

        public StepConfiguration Configuration { get; set; }

        public RemoteConfiguration Remote { get; set; }

        public Step(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task InitialiseAsync()
        {
            await _httpClient.PostAsJsonAsync(Remote.ResourceUri, Configuration);
        }

        /// <summary>
        /// Run the step .
        /// </summary>
        public async Task RunAsync()
        {
            await _httpClient.PutAsJsonAsync(Remote.ResourceUri, StepState.Running);
        }

        /// <summary>
        /// Abort running the step.
        /// </summary>
        public async Task Abort()
        {
            await _httpClient.DeleteAsync(Remote.ResourceUri);
        }
    }

    public enum StepState
    {
        Initialising,
        Waiting,
        Running
    }
}



/*

// list running counters
GET  -> http://localhost/counters

// add new counter with settings
POST -> http://localhost/counters {ID: 271, STARTAT:1, INCREMENT:5}

// run counter 271
PATCH -> http://localhost/counters/271 {STATE:run}

// get current state of counter 271
GET  -> http://localhost/counters/271 

// run counter 271 again
PATCH -> http://localhost/counters/271 {STATE:run}

// get current progress of counter 271
GET  -> http://localhost/counters/271 

// abort counter 271
PATCH -> http://localhost/counters/271 {STATE:abort}

// work complete. dispose of counter 271
DELETE  -> http://localhost/counters/271 

*/