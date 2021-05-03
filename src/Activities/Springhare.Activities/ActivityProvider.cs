// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;
using Springhare.Activities.ErrorAction;
using Springhare.Activities.LongRunningAction;
using System.Collections.Generic;

namespace Springhare.Activities
{
    public class ActivityProvider : IActivityProvider
    {
        public IEnumerable<ActivityDefinition> GetDefinitions()
        {
            return new ActivityDefinition[] 
            { 
                new LongRunningActivityDefinition(), 
                new ErrorActivityDefinition() 
            };
        }
    }
}
