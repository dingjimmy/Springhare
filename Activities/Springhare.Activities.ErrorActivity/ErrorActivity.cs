// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities.Abstractions;

namespace Springhare.Activities
{
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
