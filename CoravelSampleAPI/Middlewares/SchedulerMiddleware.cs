using Coravel;
using Coravel.Scheduling.Schedule.Interfaces;
using CoravelSampleAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;

namespace CoravelSampleAPI.Middlewares
{
    public static class SchedulerMiddleware
    {
        public static IApplicationBuilder UseScheduler(this IApplicationBuilder app)
        {
            var provider = app.ApplicationServices;
            var _logger = provider.GetService(typeof(ILogger<IScheduler>)) as ILogger<IScheduler>;

            provider.UseScheduler(scheduler=> {
                scheduler.Run(); // I am defining method to be run.
            })
            .LogScheduledTaskProgress(_logger)
            .OnError((exception) => 
            {
                // you can handle them while any error occuring.
                _logger.LogCritical(exception.Message); //it will provide to log for any error, 
            });

            return app;
        }

        public static void Run(this IScheduler scheduler)
        {
            scheduler
               .Schedule<IRunToService>() // the service that you wanted in your system is demonstrated here
               .EveryFiveSeconds()// There are lot of options for running schedule.
                //.EveryFiveMinutes() 
                // .Cron("15 9-11 * * *") //  it will run at 9:15,10:15,11:15 am
               .Zoned(TimeZoneInfo.Local); // it is a very important point to work in your local time.
        }
    }
}
