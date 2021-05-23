using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;

using Springhare.Grains.Abstractions;

namespace Springhare.Grains
{
    public class DemoActivity : Grain, IActivity
    {
        private readonly ILogger _Logger;
        private readonly IPersistentState<DemoActivityState> _State;

        public DemoActivity(ILogger logger, [PersistentState("demo", "demoStore")] IPersistentState<DemoActivityState> demoState)
        {
            _Logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _State = demoState;
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

    public class DemoActivityState
    {
        public long PulseCount { get; set; }
    }
}
