using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Springhare.Grains.Abstractions;

namespace Server
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            try
            {
                var host = await StartSilo();
                Console.WriteLine("\n\n Press Enter to terminate...\n\n");
                Console.ReadLine();

                await host.StopAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }

        private static async Task<ISiloHost> StartSilo()
        {
            // define the cluster configuration
            var builder = new SiloHostBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansBasics";
                })
                //.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IActivity).Assembly).WithReferences())
                .ConfigureLogging(logging => logging.AddConsole())
                .AddAdoNetGrainStorage("demoStore", options => 
                {
                    options.Invariant = "System.Data.SQLite";
                    options.UseJsonFormat = true;
                    options.ConnectionString = "Data Source=../data/springhare.db";
                });

            var host = builder.Build();
            await host.StartAsync();
            return host;
        }
    }
}
