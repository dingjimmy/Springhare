using System;

namespace Springhare.Workflow
{
    public class Workflow
    {
    }

    public class StepConfiguration
    {
        /// <summary>
        /// Url of the remote agent that will be run.
        /// </summary>
        public Uri AgentUrl { get; set; }

        /// <summary>
        /// How long do we wait for a response from agent, before aborting.
        /// </summary>
        public TimeSpan AgentTimeout { get; set; }
    }
}
