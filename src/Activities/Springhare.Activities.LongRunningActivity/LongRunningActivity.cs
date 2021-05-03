// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;
using System;

namespace Springhare.Activities
{
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
                    duration = new TimeSpan(0, 0, durationVal);
                    break;
                case "min":
                    duration = new TimeSpan(0, durationVal, 0);
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
