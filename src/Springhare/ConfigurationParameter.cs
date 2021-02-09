// Copyright (c) James C Dingle. All rights reserved.

using System;

namespace Springhare
{
    /// <summary>
    /// Represents a value that is used to configure how an action behaves at runtime.
    /// </summary>
    public class ConfigurationParameter
    {
        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public dynamic Value { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ConfigurationParameter" /> class.
        /// </summary>
        public ConfigurationParameter(string name, dynamic value)
        {
            Name = string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}