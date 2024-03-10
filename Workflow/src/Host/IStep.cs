using System.Threading;
using System.Threading.Tasks;

namespace Springhare.Workflow
{
    /// <summary>
    /// Represents an orderd action that performs a specific role within a wokflow.
    /// </summary>
    public interface IStep
    {
        /// <summary>
        /// Gets or sets the configuration for this step.
        /// </summary>
        StepConfiguration Configuration { get; set; }

        /// <summary>
        /// Prepares the step ready for running.
        /// </summary>
        Task InitialiseAsync(CancellationToken token);

        /// <summary>
        /// Triggers step to start running.
        /// </summary>
        Task StartAsync(CancellationToken token);

        /// <summary>
        /// Triggers the setp to abort the current run.
        /// </summary>
        Task AbortAsync(CancellationToken token);
    }
}