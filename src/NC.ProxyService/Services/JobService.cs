using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NC.ProxyService.Services
{
    public class JobService : BackgroundService
    {
        public JobService(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<JobService>();
        }

        public ILogger Logger { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("JobService is starting.");

            stoppingToken.Register(() => Logger.LogInformation("JobService is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("JobService is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Logger.LogInformation("JobService has stopped.");
        }
    }
}
