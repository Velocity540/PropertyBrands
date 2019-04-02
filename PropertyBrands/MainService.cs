using System;
using System.Threading.Tasks;

namespace PropertyBrands
{
    public interface IHostService
    {
        Task OnStart();
        void OnStop();
    }


    public class MainService : IHostService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly WeatherSettings _weatherSettings;
        private readonly IQuartzStartup _quartzStartup;

        public MainService(IServiceProvider serviceProvider, WeatherSettings weatherSettings, IQuartzStartup quartzStartup)
        {
            _serviceProvider = serviceProvider;
            _weatherSettings = weatherSettings;
            _quartzStartup = quartzStartup;
        }

        public Task OnStart()
        {
            

            return _quartzStartup.Start();
        }

        public void OnStop()
        {
        }
    }
}