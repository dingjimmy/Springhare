// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;

namespace Springhare.Actions.Abstractions
{
    /// <summary>
    /// Defines the static parts of an action such as name, description and required parameters.
    /// </summary>
    public class ActionDefinition
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the action.
        ///</Summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the display name of the Action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a summary description of the action purpose, abilities and limitations to display to end-users.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets a collection of parameter definitions.
        /// </summary>
        public IDictionary<string, ConfigurationParameterDefinition> Parameters { get; set; } = new Dictionary<string, ConfigurationParameterDefinition>();

        /// <summary>
        /// 
        /// </summary>
        public ActionConfiguration CreateConfiguration()
        {
            var config = new ActionConfiguration()
            {
                Key = this.Key,
                Name = "unnamed action"
            };

            foreach (var param in Parameters.Values)
            {
                config.Add(param.CreateConfiguration());
            }

            return config;
        }
    }
}
