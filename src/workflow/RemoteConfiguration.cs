using System;

namespace Springhare.Workflow
{
    public class RemoteConfiguration
    {
        /// <summary>
        /// Gets or sets the url of the remote resource that represents a running a step
        /// </summary>
        /// <remarks>
        /// POST initialises the step, PUT rGET retrieves current progress of the step and DEL aborts the step.
        /// </remarks>
        public Uri ResourceUri { get; set; }

        /// <summary>
        /// How long do we wait for a response from the resource, before aborting.
        /// </summary>
        public TimeSpan Timeout { get; set; }
    }
}