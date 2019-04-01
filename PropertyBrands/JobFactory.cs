using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace PropertyBrands
{
    public class JobFactory : IJobFactory, IDisposable
    {
        private readonly IServiceScope _scope;

        public JobFactory(IServiceProvider container)
        {
            _scope = container.CreateScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var res = _scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
            return res;
        }

        public void ReturnJob(IJob job)
        {
            (job as IDisposable)?.Dispose();
        }
    }
}