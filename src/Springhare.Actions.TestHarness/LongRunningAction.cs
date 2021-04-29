// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Actions.Abstractions;
using System;

namespace Springhare
{
    /// <summary>
    /// 
    /// </summary>
    public class LongRunningActionDefinition : ActionDefinition
    {
        public LongRunningActionDefinition()
        {
            Key = "LRA";
            Name = "Long Running Action";
            Description = "Simulates an action that takes a long time to run";
            Parameters = new[]
            {
                new ConfigurationParameterDefinition() { Name = "Duration.Value", Catagory = "General" },
                new ConfigurationParameterDefinition() { Name = "Duration.Unit", Catagory = "General" }
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LongRunningAction : IActionRuntime
    {
        public string Key => "LRA";

        public ActionConfiguration Configuration { get; set; } = new ActionConfiguration();

        public ActionResult Execute()
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
                    return ActionResult.Failed;
            }

            System.Threading.Tasks.Task.Delay(duration).Wait();

            return ActionResult.Success;
        }

        public ActionResult Setup()
        {
            return ActionResult.Success;
        }

        public ActionResult Teardown()
        {
            return ActionResult.Success;
        }
    }
}
