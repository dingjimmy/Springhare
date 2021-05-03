using Spectre.Console;
using Spectre.Console.Cli;
using Springhare.Actions.Abstractions;
using System;
using System.Linq;

namespace Springhare.Actions.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            IActionProvider provider = new ActionProvider();



            // 1. Choose Actions
            var choosePrompt = new SelectionPrompt<string>()
                .Title("Select an action to run...");

            var definitions = provider.GetDefinitions()
                .ToDictionary(x => x.Name, x => x);

            foreach (var ad in definitions.Keys)
            {
                choosePrompt.AddChoice(ad);
            }

            var choice = AnsiConsole.Prompt(choosePrompt);
            var definition = definitions[choice];




            // 2. Configure Action
            AnsiConsole.MarkupLine($"Configure {definition.Name}");

            var config = definition.CreateConfiguration();

            foreach (var param in config)
            {
                param.Value = AnsiConsole.Ask<string>($"{definition.Parameters[param.Key].Name}: ");
            }



            // 3. Execute Action


        }
    }
}
