// Copyright (c) James C Dingle. All rights reserved.:warning

using System.Collections.Generic;

namespace Springhare
{
    /// <summary>
    /// Represents an action that need to be performed by a 3rd party device, application or service.
    /// </summary>
    public class Action
    {
        ///<Summary>
        /// Gets or sets a value which uniquley identifies the action.
        ///</Summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets human-friendly name to help users to identify the Action.
        /// </summary>
        public string Name { get; set; }

        // <summary>
        /// Gets a collection of paramters that configure the actions behaviour.
        /// </summary>
        public List<ConfigurationParameter> Configuration { get; set; }

        /// <summary>
        /// Sets-up the action ready for execution. 
        /// </summary>
        public void Setup()
        {

        }

        /// <summary>
        /// Executes the primary logic of the action.
        /// </summary>
        public void Execute()
        {

        }

        /// <summary>
        /// Tears-down the action after execution has completed.
        /// </summary>
        /// <remarks>For Example: freeing resources, closing connections and putting 3rd party devices, software or services into a good state.</remarks>
        public void Teardown()
        {

        }
    }
}
