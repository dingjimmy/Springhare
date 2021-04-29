// Copyright (c) James C Dingle. All rights reserved.

using System.Collections;
using System.Collections.Generic;

namespace Springhare.Actions.Abstractions
{
    /// <summary>
    /// Represents a configured instance of an Action; a collection of paramters that configure the actions behaviour at runtime.
    /// </summary>
    public class ActionConfiguration : ICollection<ConfigurationParameter>
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the configured Action.
        ///</Summary>
        public uint Id { get; set; }

        ///<Summary>
        /// Gets or sets a value which uniquley identifies the action being configured.
        ///</Summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets human-friendly name to help users to identify the configured Action. Default value is 'unnamed configuration'.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ActionConfiguration"/> class.
        /// </summary>
        public ActionConfiguration()
        {
            Name = "unnamed configuration";
        }

        #region ICollection<T> Implementation

        private readonly Dictionary<string, ConfigurationParameter> _Parameters = new Dictionary<string, ConfigurationParameter>();
        
        public int Count => _Parameters.Count;

        public bool IsReadOnly => false;

        public dynamic this[string name]
        {
            get
            {
                return _Parameters[name].Value;
            }

            set
            {
                _Parameters[name].Value = value;
            }
        }

        public bool Contains(ConfigurationParameter item)
        {
            return _Parameters.ContainsKey(item.Name);
        }

        public void Add(string name, dynamic value)
        {
            var param = new ConfigurationParameter(name, value);
            _Parameters.Add(param.Name, param);
        }

        public void Add(ConfigurationParameter item)
        {
            _Parameters.Add(item.Name, item);
        }

        public bool Remove(string name)
        {
            return _Parameters.Remove(name);
        }

        public bool Remove(ConfigurationParameter item)
        {
            return _Parameters.Remove(item.Name);
        }

        public void Clear()
        {
            _Parameters.Clear();
        }

        public void CopyTo(ConfigurationParameter[] array, int arrayIndex)
        {
            _Parameters.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ConfigurationParameter> GetEnumerator()
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
