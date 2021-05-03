// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Activities;
using Springhare.Activities.Abstractions;
using System.Linq;

namespace Springhare.Activities.TestHarness
{
    class ActionHarness
    {
        public ActionHarness() 
        {

            //// get definitions
            //IActionProvider provider = new ActionProvider();
            //var defs = provider.GetDefinitions();
            

            //// find long running action and create config from definition
            //var lraConfig = defs
            //    .First(x => x.Key == "LRA")
            //    .CreateConfiguration();


            //// configure the config
            //lraConfig.Name = "Long Running Action 1";
            //lraConfig["Duration.Value"] = 1;
            //lraConfig["Duration.Unit"] = "min";


            //// run the action using the config
            //var lra = new LongRunningAction()
            //{
            //    Configuration = lraConfig
            //};

            //if (lra.Setup() == ActionResult.Success)
            //{
            //    lra.Execute();
            //}

            //lra.Teardown();

        }
    }
}
