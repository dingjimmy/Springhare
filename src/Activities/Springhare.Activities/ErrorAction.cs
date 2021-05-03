// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;
using System.Linq;

namespace Springhare.Activities.ErrorAction
{
    public class ErrorActivityDefinition : ActivityDefinition
    {
        public ErrorActivityDefinition()
        {
            Key = "ERA";
            Name = "Error Activity";
            Description = "Simulates an activity that causes errors.";
            Parameters.Add("ErrorRate",
                new ParameterDefinition()
                {
                    Key = "ErrorRate",
                    Name = "Error Rate (%)",
                    Catagory = "General",
                    Description = "No of times per 100 executions, that an error occours."
                });
        }

        public override IActivity CreateActivity() => new ErrorActivity();

    }
    public class ErrorActivity : IActivity
    {
        public string Key => "ERA";

        public ActivityConfiguration Configuration { get; set; }

        public ActivityResult Execute()
        {
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
