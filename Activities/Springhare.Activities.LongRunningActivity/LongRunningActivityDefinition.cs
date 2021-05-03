// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;

namespace Springhare.Activities
{
    /// <summary>
    /// 
    /// </summary>
    public class LongRunningActivityDefinition : ActivityDefinition
    {
        public LongRunningActivityDefinition()
        {
            Key = "LRA";
            Name = "Long Running Activity";
            Description = "Simulates an activity that takes a long time to execute";

            Parameters.Add("Duration.Value",
                new ParameterDefinition()
                {
                    Key = "Duration.Value",
                    Name = "Duration",
                    Catagory = "General",
                    Description = "The length of time the activity should execute for.",
                    DefaultValue = "30"
                });

            Parameters.Add("Duration.Unit",
                new ParameterDefinition()
                {
                    Key = "Duration.Unit",
                    Name = "Units",
                    Catagory = "General",
                    AvailableValues = new string[] { "Seconds", "Minuites" },
                    Description = "The unit of time to use ",
                    DefaultValue = "Seconds"
                });
        }

        public override IActivity CreateActivity() => new LongRunningActivity();
    }
}
