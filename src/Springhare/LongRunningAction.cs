// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;

namespace Springhare
{
    public class LongRunningAction : IAction
    {
        public uint Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ConfigurationParameter> Configuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ActionResult Execute()
        {
            TimeSpan duration;

            int durationVal = Configuration[1].Value;

            switch (Configuration[2].Value)
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
