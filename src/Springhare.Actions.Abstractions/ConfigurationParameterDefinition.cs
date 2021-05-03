// Copyright (c) James C Dingle. All rights reserved.

using System.Collections.Generic;

namespace Springhare.Actions.Abstractions
{
    /// <summary>
    /// Defines a configuration parameter that is required for an action to operate. 
    /// </summary>
    public class ConfigurationParameterDefinition
    {
         /// <summary>
        /// Gets or sets a value which uniquley identifies the parameter within the action.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the display name of the parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display catagory/grouping of the parameter.
        /// </summary>
        public string Catagory { get; set; }

        /// <summary>
        /// Gets or sets a summary desription of the parameters purpose to end-users.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the default value for this parameter.
        /// </summary>
        public string DefaultValue { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a collection of set values for a user to choose from.
        /// </summary>
        public IEnumerable<string> AvailableValues { get; set; }


        // TODO: data type?
        //public ConfigurationParameterDataType DataType { get; set; }

        // TODO: validation rules?
        //public ConfigurationParameterRules { get; set; }


        /// <summary>
        /// Creates a new instance of the <see cref="ConfigurationParameter"/> class, using the info from this definition.
        /// </summary>
        public ConfigurationParameter CreateConfiguration()
        {
            return new ConfigurationParameter(Name, DefaultValue);
        }
    }
}