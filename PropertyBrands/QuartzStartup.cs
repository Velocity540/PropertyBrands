using System;
using Quartz;
using Quartz.Impl;

namespace PropertyBrands
{
    public class QuartzStartup
    {
        private readonly IServiceProvider _container;
        private readonly WeatherSettings _weatherSettings;
        private IScheduler _scheduler;

        public QuartzStartup(IServiceProvider container, WeatherSettings weatherSettings)
        {
            _container = container;
            _weatherSettings = weatherSettings;
        }

        public void Start()
        {
            if (_scheduler != null)
            {
                throw new InvalidOperationException("Already started.");
            }

            var schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.JobFactory = new JobFactory(_container);
            _scheduler.Start().Wait();

            foreach (var weatherSetting in _weatherSettings.ZipCodeIntervals)
            {
                var voteJob = JobBuilder.Create<WeatherDataLoadJob>().UsingJobData("ZipCode", weatherSetting.ZipCode).Build();

                var voteJobTrigger = TriggerBuilder.Create().StartNow().WithSimpleSchedule(s => s.WithIntervalInSeconds(weatherSetting.Interval).RepeatForever()).Build();

                _scheduler.ScheduleJob(voteJob, voteJobTrigger).Wait();
            }
        }

        public void Stop()
        {
            if (_scheduler == null)
            {
                return;
            }

            if (_scheduler.Shutdown(true).Wait(30000))
            {
                _scheduler = null;
            }
        }
    }
}