using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace IHostingStartupTest
{
    public class ConfigureApp : IStartup
    {
        public ConfigureApp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            return services.BuildServiceProvider();
        }

        private IConfiguration Configuration { get; set; }

        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine(Configuration.GetSection("Test").GetValue<string>("TestValue"));
        }
    }
}