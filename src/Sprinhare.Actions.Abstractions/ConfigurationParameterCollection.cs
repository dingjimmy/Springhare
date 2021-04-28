// Copyright (c) James C Dingle. All rights reserved.

using System.Collections;
using System.Collections.Generic;

namespace Springhare.Actions.Abstractions
{
    public class ConfigurationParameterCollection : ICollection<ConfigurationParameter>
    {
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
    }
}
