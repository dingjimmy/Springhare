// Copyright (c) James C Dingle. All rights reserved.

using System.Collections;
using System.Collections.Generic;

namespace Springhare.Activities.Abstractions
{
    /// <summary>
    /// A collection of paramters that configure an activities behaviour at runtime.
    /// </summary>
    public interface IActivityConfiguration
    {
        /// <summary>
        /// Gets or sets user-provided name to help identify the configuration.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the specified parameter.
        /// </summmary>
        dynamic this[string key] { get; set; }
    }
}
