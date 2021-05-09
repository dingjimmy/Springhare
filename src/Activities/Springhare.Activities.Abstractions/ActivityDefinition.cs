// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;

namespace Springhare.Activities.Abstractions
{
    /// <summary>
    /// Defines the static parts of an activity such as name, description and required parameters.
    /// </summary>
    public abstract class ActivityDefinition
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the activity being defined.
        ///</Summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the display name of the Activity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a summary description of the activities purpose, abilities and limitations to display to end-users.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a collection of parameter definitions.
        /// </summary>
        public IDictionary<string, ParameterDefinition> Parameters { get; set; } = new Dictionary<string, ParameterDefinition>();

        /// <summary>
        /// Creates a runtime for the desired activity.
        /// </summary>
        public abstract IActivity CreateActivity();
    }
}
