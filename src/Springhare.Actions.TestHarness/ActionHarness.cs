// Copyright (c) James C Dingle. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Springhare
{
    class ActionHarness
    {
        public ActionHarness()
        {
            var lra = new LongRunningAction();
            lra.Configuration.Add(new ConfigurationParameter("Name", "Long Running Action 1"));
            lra.Configuration.Add(new ConfigurationParameter("Duration.Value", 1));
            lra.Configuration.Add(new ConfigurationParameter("Duration.Unit", "min"));

            

            if (lra.Setup() == ActionResult.Success)
            {
                lra.Execute();
            }

            lra.Teardown();

        }
    }
}
