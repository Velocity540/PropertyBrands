using System;
using System.IO;
using System.Threading.Tasks;
using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;
using Topshelf;

namespace PropertyBrands
{
    internal class Program
    {
        private static Container _serviceProvider;

        private static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json");

            var config = builder.Build();

            RegisterServices(config);

            HostFactory.Run(x =>
            {
                x.Service<HostService>(s =>
                {
                    s.ConstructUsing(hostSettings => (HostService) _serviceProvider.GetInstance<IHostService>());

                    s.WhenStarted(ss => ss.OnStart());
                    s.WhenStopped(ss => ss.OnStop());
                });

                x.RunAsLocalSystem().DependsOnEventLog().StartAutomatically().EnableServiceRecovery(rc => rc.RestartService(1));

                x.SetServiceName("My Service");
                x.SetDisplayName("My Service");
                x.SetDescription("My Service's description");
            });
        }

        private static void RegisterServices(IConfiguration config)
        {

            var weatherSettings = config.GetSection("WeatherSettings").Get<WeatherSettings>();

            var container = new Container(x =>
            {
                x.Scan(s =>
                {
                    s.TheCallingAssembly();
                    s.WithDefaultConventions();
                    s.LookForRegistries();
                });


                x.AddSingleton(weatherSettings);
                x.AddHttpClient<IWeatherDataLoadService, WeatherDataLoadService>().SetHandlerLifetime(TimeSpan.FromMinutes(5));
                x.AddTransient<WeatherDataLoadJob>();
            });

            Console.WriteLine(container.WhatDoIHave());
            Console.WriteLine(container.WhatDidIScan());

            _serviceProvider = container;

        }
    }
}