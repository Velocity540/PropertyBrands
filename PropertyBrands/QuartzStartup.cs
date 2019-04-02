using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace PropertyBrands
{
    public interface IQuartzStartup
    {
        Task Start();
        void Stop();
    }

    public class QuartzStartup : IQuartzStartup
    {
        private readonly IServiceProvider _container;
        private readonly WeatherSettings _weatherSettings;
        private IScheduler _scheduler;

        public QuartzStartup(IServiceProvider container, WeatherSettings weatherSettings)
        {
            _container = container;
            _weatherSettings = weatherSettings;
        }

        public async Task Start()
        {
            if (_scheduler != null)
            {
                throw new InvalidOperationException("Already started.");
            }

            var schedulerFactory = new StdSchedulerFactory();
            _scheduler = await schedulerFactory.GetScheduler();
            _scheduler.JobFactory = new JobFactory(_container);
            
            await _scheduler.Start();

            foreach (var weatherSetting in _weatherSettings.ZipCodeIntervals)
            {
                var voteJob = JobBuilder.Create<WeatherDataLoadJob>().UsingJobData("ZipCode", weatherSetting.ZipCode).Build();

                var voteJobTrigger = TriggerBuilder.Create().StartNow().WithSimpleSchedule(s => s.WithIntervalInSeconds(weatherSetting.Interval).RepeatForever()).Build();

                await _scheduler.ScheduleJob(voteJob, voteJobTrigger);
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