// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Actions.Abstractions;

namespace Springhare
{
    public class ErrorAction : IActionRuntime
    {
        public string Key => "ERA";

        public ActionConfiguration Configuration { get; set; }

        public ActionResult Execute()
        {
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
