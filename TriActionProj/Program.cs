using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TestAngularProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO need this line when developing from work in order for the application to start because I am behind a proxy - not sure if it's needed from home.
            AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
        }
}
