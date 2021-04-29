// Copyright (c) James C Dingle. All rights reserved.

namespace Springhare.Actions.Abstractions
{
    /// <summary>
    /// Represents the runtime operation of an action that needs to be performed.
    /// </summary>
    public interface IActionRuntime
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the action.
        ///</Summary>
        string Key { get; }

        /// <summary>
        /// The configuration to use when performing the action.
        /// </summary>
        ActionConfiguration Configuration { get; set; }

        /// <summary>
        /// Sets-up the action ready for execution. 
        /// </summary>
        public ActionResult Setup();

        /// <summary>
        /// Executes the primary logic of the action.
        /// </summary>
        public ActionResult Execute();

        /// <summary>
        /// Tears-down the action after execution has completed.
        /// </summary>
        /// <remarks>For Example: freeing resources, closing connections and putting 3rd party devices, software or services into a good state.</remarks>
        public ActionResult Teardown();
    }

    public enum ActionResult
    {
        Failed = -1,
        Success = 0
    }
}
