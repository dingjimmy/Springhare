using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Springhare.Workflow
{

    public class StepProxy : IStep
    {
        private readonly HttpClient _httpClient;

        public string Name { get; set; }

        public StepConfiguration Configuration { get; set; }

        public RemoteConfiguration Remote { get; set; }

        /// <summary>
        /// Creates a new instance of the <see 
        /// </summary>
        public StepProxy(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Prepares the step ready for running.
        /// </summary>
        public async Task InitialiseAsync(CancellationToken token)
        {
            await _httpClient.PostAsJsonAsync(Remote.ResourceUri, Configuration);
        }

        // /// <summary>
        // /// Retrieves the current progress of the step.
        // /// </summary>
        // private async Task<StepProgress> CheckProgressAsync()
        // {
        //     var response = await _httpClient.GetAsync(Remote.ResourceUri);

        //     if (!response.IsSuccessStatusCode) throw new CheckStepProgressFailedException();

        //     return await response.Content.ReadFromJsonAsync<StepProgress>();
        // }

        /// <summary>
        /// Triggers step to start running.
        /// </summary>
        public async Task StartAsync(CancellationToken token)
        {
            var response = await _httpClient.PutAsJsonAsync(Remote.ResourceUri, StepState.Running);

            if (!response.IsSuccessStatusCode) throw new StartStepFailedException();
        }

        /// <summary>
        /// Triggers the setp to abort the current run.
        /// </summary>
        public async Task AbortAsync(CancellationToken token)
        {
            var response = await _httpClient.DeleteAsync(Remote.ResourceUri);

            if (!response.IsSuccessStatusCode) throw new AbortStepFailedException();
        }
    }

    public enum StepState
    {

        Initialising,
        Waiting,
        Running,
        Successfull,
        Aborted
    }

    public class StepProgress
    {
        public StepState State { get; set; }    
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