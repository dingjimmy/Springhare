using System;
using System.Threading.Tasks;
using Orleans;

namespace Springhare.Grains.Abstractions
{
    public interface IActivity : IGrainWithGuidKey
    {
        Task Startup();

        Task Pulse();

        Task Teardown();
    }
}
