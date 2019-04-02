using System;
using System.Threading.Tasks;
using Quartz;

namespace PropertyBrands
{
    [DisallowConcurrentExecution]
    public class WeatherDataLoadJob : IJob
    {
        private readonly IWeatherDataLoadService _weatherDataLoadService;

        public WeatherDataLoadJob(IWeatherDataLoadService weatherDataLoadService)
        {
            _weatherDataLoadService = weatherDataLoadService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;

            var zipCode = dataMap.GetString("ZipCode");

            var tt = await _weatherDataLoadService.GetWeatherData(zipCode);

            // ToDo Save to database? Post to internal micro-servie?

            Console.WriteLine(tt.City.Name);
        }
    }
}