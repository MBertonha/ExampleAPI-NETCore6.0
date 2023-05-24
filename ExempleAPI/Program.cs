using Microsoft.AspNetCore;


namespace ExempleAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var hostConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hostconfig.json")
                .Build();

            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseConfiguration(hostConfig)
                .Build();

            host.Run();
        }
    }
}
