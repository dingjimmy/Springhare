// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Actions.Abstractions;
using Springhare.Actions.ErrorAction;
using Springhare.Actions.LongRunningAction;
using System.Collections.Generic;

namespace Springhare.Actions
{
    public class ActionProvider : IActionProvider
    {
        public IEnumerable<ActionDefinition> GetDefinitions()
        {
            return new ActionDefinition[] 
            { 
                new LongRunningActionDefinition(), 
                new ErrorActionDefinition() 
            };
        }
    }
}
