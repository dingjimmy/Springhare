// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;
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
