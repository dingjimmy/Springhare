// Copyright (c) James C Dingle. All rights reserved.

namespace Springhare.Activities.Abstractions
{
    /// <summary>
    /// Represents the runtime operation of an activity that needs to be performed.
    /// </summary>
    public interface IActivity
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the activity.
        ///</Summary>
        string Key { get; }

        /// <summary>
        /// The configuration to use when executing the activity.
        /// </summary>
        IActivityConfiguration Configuration { get; set; }

        /// <summary>
        /// Sets-up the activity ready for execution. 
        /// </summary>
        public ActivityResult Setup();

        /// <summary>
        /// Executes the primary logic of the activity.
        /// </summary>
        public ActivityResult Execute();

        /// <summary>
        /// Tears-down the activity after execution has completed.
        /// </summary>
        /// <remarks>For Example: freeing resources, closing connections and putting 3rd party devices, software or services into a good state.</remarks>
        public ActivityResult Teardown();
    }

    public enum ActivityResult
    {
        Failed = -1,
        Success = 0
    }
}
