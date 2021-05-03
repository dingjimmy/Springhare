// Copyright (c) James C Dingle. All rights reserved.

using System.Collections.Generic;

namespace Springhare.Activities.Abstractions
{
    public interface IActivityProvider
    {
        IEnumerable<ActivityDefinition> GetDefinitions();
    }
}
