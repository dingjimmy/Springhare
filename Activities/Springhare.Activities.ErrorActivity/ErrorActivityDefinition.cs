// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;

namespace Springhare.Activities
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
}
