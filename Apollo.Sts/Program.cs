using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Apollo.Sts
{
    public class Program
    {
        public static void Main(string[] args)
        {
             CreateWebHostBuilder(args).Build().Run();

            // var config = new ConfigurationBuilder()
            //       .AddCommandLine(args)
            //       .Build();

            //BuildWebHost(args, config).Run(); 
        }

          public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();  
          
           //  public static IWebHost BuildWebHost(string[] args, IConfigurationRoot configuration) =>
           //WebHost.CreateDefaultBuilder(args)
           //    .UseStartup<Startup>()
           //    .UseConfiguration(configuration)
           //     .UseUrls(args[1])
           //    .Build();
    }
}
