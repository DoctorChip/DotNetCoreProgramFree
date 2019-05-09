using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IHostingStartupTest.ConfigureHost))]
namespace IHostingStartupTest
{
    public class ConfigureHost : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder
                .UseKestrel()
                .UseStartup<ConfigureApp>();
        }

        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .Build()
                .Run();
        }
    }
}