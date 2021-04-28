// Copyright (c) James C Dingle. All rights reserved.

using System;

namespace Springhare
{
    public class LongRunningAction : IAction
    {
        public uint Id { get; set; }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ConfigurationParameterCollection Configuration { get; set; }

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
