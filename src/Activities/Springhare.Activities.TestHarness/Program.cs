using Spectre.Console;
using Spectre.Console.Cli;
using Springhare.Activities.Abstractions;
using System;
using System.Linq;

namespace Springhare.Activities.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            IActivityProvider provider = new ActivityProvider();



            // 1. Choose Activitys
            var choosePrompt = new SelectionPrompt<string>()
                .Title("Select an Activity to run...");

            var definitions = provider.GetDefinitions()
                .ToDictionary(x => x.Name, x => x);

            foreach (var ad in definitions.Keys)
            {
                choosePrompt.AddChoice(ad);
            }

            var choice = AnsiConsole.Prompt(choosePrompt);
            var definition = definitions[choice];




            // 2. Configure Activity
            AnsiConsole.MarkupLine($"Configure {definition.Name}");

            var config = definition.CreateConfiguration();

            foreach (var param in config)
            {
                param.Value = AnsiConsole.Ask<string>($"{definition.Parameters[param.Key].Name}: ");
            }



            // 3. Execute Activity


        }
    }
}
