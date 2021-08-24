using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Springhare.Workflow
{
    public class Workflow
    {
        private TimeSpan _StepTimeout = new TimeSpan(0,0,0,1);

        public IEnumerable<IStep> Steps { get; set; }

        public async Task Start()
        {

            foreach (var step in Steps)
            {
                using (var cts = new CancellationTokenSource(_StepTimeout))
                {
                    await step.InitialiseAsync(cts.Token);
                }
            }

            foreach (var step in Steps)
            {
                using (var cts = new CancellationTokenSource(_StepTimeout))
                {
                    await step.StartAsync(cts.Token);
                }
            }

        }

        public async Task Stop()
        {
            foreach (var step in Steps) 
            {
                using (var cts = new CancellationTokenSource(_StepTimeout))
                {
                    await step.AbortAsync(cts.Token);
                }
            }
        }
    }
}
