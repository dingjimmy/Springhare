// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springhare.Actions.Abstractions
{
    /// <summary>
    /// Represents a configured instance of an <see cref="Abstractions.Action"/>
    /// </summary>
    public class ActionConfiguration
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the configured Action.
        ///</Summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets human-friendly name to help users to identify the configured Action. Default value is 'unnamed configuration'.
        /// </summary>
        public string Name { get; set; }

        // <summary>
        /// Gets a collection of paramters that configure the actions behaviour at runtime.
        /// </summary>
        public ConfigurationParameterCollection Configuration { get; }

        public ActionConfiguration()
        {
            Name = "unnamed configuration";
            Configuration = new ConfigurationParameterCollection();
        }
    }
}
