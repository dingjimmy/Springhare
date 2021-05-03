// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springhare.Actions.Abstractions
{
    public interface IActionProvider
    {
        IEnumerable<ActionDefinition> GetDefinitions();
    }
}
