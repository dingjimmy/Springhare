using Spectre.Console;
using System.Linq;

namespace Springhare.Activities.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivityProvider provider = new ActivityProvider();

            // init provider.
            provider.LoadDefinitions(@"../../../src/Activities");



            // 1. Choose Activitys
            var choosePrompt = new SelectionPrompt<string>()
                .Title("Select an Activity to run...");

            var definitions = provider
                .GetDefinitions()
                .ToDictionary(x => x.Name, x => x);

            foreach (var ad in definitions.Keys)
            {
                choosePrompt.AddChoice(ad);
            }

            var choice = AnsiConsole.Prompt(choosePrompt);
            var definition = definitions[choice];




            // 2. Configure Activity
            AnsiConsole.MarkupLine($"Configure {definition.Name}");

            var config = Configuration.CreateConfiguration(definition);

            foreach (var param in config)
            {
                var paramDef = definition.Parameters[param.Key];

                if (!paramDef.AvailableValues.Any())
                {
                    param.Value = AnsiConsole.Ask<string>($"{paramDef.Name}: ");
                }
                else
                {
                    var prompt = new SelectionPrompt<string>()
                        .Title($"{paramDef.Name}: ")
                        .AddChoices(paramDef.AvailableValues);                    

                    param.Value = AnsiConsole.Prompt(prompt);
                }
            }

            // 3. Execute Activity
            foreach (var param in config)
            {
                AnsiConsole.MarkupLine($"[Purple]{param.Key}:[/] {param.Value}");
            }

        }
    }
}
