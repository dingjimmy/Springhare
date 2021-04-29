// Copyright (c) James C Dingle. All rights reserved.

using Springhare.Actions.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Springhare
{
    class ActionHarness
    {
        public ActionHarness()
        {
            
            // get definitions
            IEnumerable<ActionDefinition> defs = IActionProvider.GetDefinitions();
            

            // find long running action and create config from definition
            var lraConfig = defs
                .First(x => x.Key == "LRA")
                .CreateConfiguration();


            // configure the config
            lraConfig.Name = "Long Running Action 1";
            lraConfig["Duration.Value"] = 1;
            lraConfig["Duration.Unit"] = "min";


            // run the action using the config
            var lra = new LongRunningAction()
            {
                Configuration = lraConfig
            };

            if (lra.Setup() == ActionResult.Success)
            {
                lra.Execute();
            }

            lra.Teardown();

        }
    }
}
