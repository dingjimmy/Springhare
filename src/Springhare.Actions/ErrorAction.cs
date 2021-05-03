// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Actions.Abstractions;
using System.Linq;

namespace Springhare.Actions.ErrorAction
{
    public class ErrorActionDefinition : ActionDefinition
    {
        public ErrorActionDefinition()
        {
            Key = "ERA";
            Name = "Error Action";
            Description = "Simulates an action that causes errors.";
            Parameters.Add("ErrorRate",
                new ConfigurationParameterDefinition()
                {
                    Key = "ErrorRate",
                    Name = "Error Rate (%)",
                    Catagory = "General",
                    Description = "No of times per 100 executions, that an error occours."
                });
        }

        public override IActionRuntime CreateAction() => new ErrorAction();

    }
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
