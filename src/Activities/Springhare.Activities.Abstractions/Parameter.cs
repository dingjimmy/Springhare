// Copyright (c) James C Dingle. All rights reserved.

using System;

namespace Springhare.Activities.Abstractions
{
    /// <summary>
    /// Represents a value that is used to configure how an action behaves at runtime.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Gets the key of the parameter.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public dynamic Value { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        public Parameter(string key, dynamic value)
        {
            Key = !string.IsNullOrWhiteSpace(key) ? key : throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}