// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;
using System;

namespace Springhare.Activities.LongRunningAction
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

    /// <summary>
    /// 
    /// </summary>
    public class LongRunningActivity : IActivity
    {
        public string Key => "LRA";

        public ActivityConfiguration Configuration { get; set; }

        public ActivityResult Execute()
        {
            TimeSpan duration;

            int durationVal = Configuration["Duration.Value"];

            switch (Configuration["Duration.Unit"])
            {
                case "sec":
                    duration = new TimeSpan(durationVal, 0, 0);
                    break;
                case "min":
                    duration = new TimeSpan(durationVal, 0, 0);
                    break;
                case "hour":
                    duration = new TimeSpan(durationVal, 0, 0);
                    break;
                default:
                    return ActivityResult.Failed;
            }

            System.Threading.Tasks.Task.Delay(duration).Wait();

            return ActivityResult.Success;
        }

        public ActivityResult Setup()
        {
            return ActivityResult.Success;
        }

        public ActivityResult Teardown()
        {
            return ActivityResult.Success;
        }
    }
}
