// Copyright (c) James C Dingle. All rights reserved.

namespace Springhare.Actions.Abstractions
{
    /// <summary>
    /// Defines a configuration parameter that is required for an action to operate. 
    /// </summary>
    public class ConfigurationParameterDefinition
    {
        public string Name { get; set; }

        public string Catagory { get; set; }

        // TODO: data type?
        //public ConfigurationParameterDataType DataType { get; set; }

        // TODO: validation rules?
        //public ConfigurationParameterRules { get; set; }

        public ConfigurationParameter CreateConfiguration()
        {
            return new ConfigurationParameter(Name, null);
        }
    }
}