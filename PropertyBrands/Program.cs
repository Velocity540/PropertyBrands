using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;
using Topshelf;

namespace PropertyBrands
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");

            var config = builder.Build();

            RegisterServices(config);

            HostFactory.Run(x =>
            {
                x.Service<MainService>(s =>
                {
                    s.ConstructUsing(() => new MainService());
                    s.WhenStarted(ss => ss.OnStart());
                    s.WhenStopped(ss => ss.OnStop());
                });

                x.RunAsLocalSystem().DependsOnEventLog().StartAutomatically().EnableServiceRecovery(rc => rc.RestartService(1));

                x.SetServiceName("My Service");
                x.SetDisplayName("My Service");
                x.SetDescription("My Service's description");
            });
        }

        private static void RegisterServices(IConfigurationRoot config)
        {
            var services = new ServiceCollection();

            var weatherSettings = config.GetSection("WeatherSettings").Get<WeatherSettings>();

            services.AddScoped<IWeatherDataLoadService, WeatherDataLoadService>();
            services.AddSingleton(weatherSettings);

            services.AddHttpClient<IWeatherDataLoadService, WeatherDataLoadService>().SetHandlerLifetime(TimeSpan.FromMinutes(5));


            services.AddTransient<IJobFactory, JobFactory>(provider => new JobFactory(services.BuildServiceProvider()));
            services.AddTransient<WeatherDataLoadJob>();

            _serviceProvider = services.BuildServiceProvider();

            var quartz = new QuartzStartup(_serviceProvider, weatherSettings);

            quartz.Start();
        }
    }
}