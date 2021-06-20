using System;
using System.Net.Http;

namespace Springhare.Workflow
{
    public class Step
    {
        private readonly HttpClient _httpClient;

        public string Name { get; set; }

        public StepConfiguration Configuration { get; set; }

        public Step(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public void Run()
        {
            _httpClient.PostAsync()
        }

        public void Abort()
        {

        }
    }
}
