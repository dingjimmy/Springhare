using System;

namespace Springhare.Workflow
{
    public class RemoteConfiguration
    {
        /// <summary>
        /// Gets or sets the url of the remote resource that represents a running a step
        /// </summary>
        /// <remarks>
        /// POST creates and initialises the step, PATCH starts and stops the step, GET retrieves current progress, and DEL removes the step from memory.
        /// </remarks>
        public Uri ResourceUri { get; set; }

        /// <summary>
        /// How long do we wait for a response from the resource, before aborting.
        /// </summary>
        public TimeSpan Timeout { get; set; }
    }
}