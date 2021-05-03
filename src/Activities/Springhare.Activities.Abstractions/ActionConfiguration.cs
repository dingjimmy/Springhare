// Copyright (c) James C Dingle. All rights reserved.

using System.Collections;
using System.Collections.Generic;

namespace Springhare.Activities.Abstractions
{
    /// <summary>
    /// A collection of paramters that configure an activities behaviour at runtime.
    /// </summary>
    public class ActivityConfiguration : ICollection<Parameter>
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the activity being configured.
        ///</Summary>
        public uint Id { get; set; }

        ///<Summary>
        /// Gets or sets a value which uniquley identifies the activity being configured.
        ///</Summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets human-friendly name to help users to identify the configured activity. Default value is 'unnamed configuration'.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ActivityConfiguration"/> class.
        /// </summary>
        public ActivityConfiguration()
        {
            Name = "unnamed configuration";
        }

        #region ICollection<T> Implementation

        private readonly Dictionary<string, Parameter> _Parameters = new Dictionary<string, Parameter>();
        
        public int Count => _Parameters.Count;

        public bool IsReadOnly => false;

        public dynamic this[string key]
        {
            get
            {
                return _Parameters[key].Value;
            }

            set
            {
                _Parameters[key].Value = value;
            }
        }

        public bool Contains(Parameter item)
        {
            return _Parameters.ContainsKey(item.Key);
        }

        public void Add(string name, dynamic value)
        {
            var param = new Parameter(name, value);
            _Parameters.Add(param.Key, param);
        }

        public void Add(Parameter item)
        {
            _Parameters.Add(item.Key, item);
        }

        public bool Remove(string name)
        {
            return _Parameters.Remove(name);
        }

        public bool Remove(Parameter item)
        {
            return _Parameters.Remove(item.Key);
        }

        public void Clear()
        {
            _Parameters.Clear();
        }

        public void CopyTo(Parameter[] array, int arrayIndex)
        {
            _Parameters.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return _Parameters.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Parameters.Values.GetEnumerator();
        }
        #endregion
    }
}
