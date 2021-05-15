using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Orleans;
using Springhare.Activities.Abstractions;

namespace Springhare.Grains
{
    public class DemoActivity : Grain, IActivity
    {
        private readonly ILogger _Logger;

        public DemoActivity(ILogger logger)
        {
            _Logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task Startup()
        {
            _Logger.LogInformation("Startup 'Demo Activity'!");

            await Task.Delay(2000);
        }

        public async Task Pulse()
        {
            _Logger.LogInformation("Pulse 'Demo Activity'");

            await Task.Delay(2000);
        }

        public async Task Teardown()
        {
            _Logger.LogInformation("Teardown 'Demo Activity'");

            await Task.Delay(2000);
        }
    }
}
