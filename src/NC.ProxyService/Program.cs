using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NC.ProxyService.Services;
using System.Net;

namespace NC.ProxyService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[]args)=>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<JobService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel(options =>
                    //{
                    //    options.ListenAnyIP(3000);
                    //});
                    webBuilder.UseStartup<Startup>();
                })
                .UseWindowsService();
    }
}
