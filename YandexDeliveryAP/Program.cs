using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;
using System;
using Serilog.Exceptions;
using Microsoft.AspNetCore.Hosting;

namespace YandexDeliveryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            try
            {
                ConfigureLogging();
                CreateHostBuilder(args)
                    .Build()
                    .Run();

            }
            catch (Exception ex)
            {
                Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                      .ConfigureWebHostDefaults(webBuilder =>
                      {
                          webBuilder
                           .UseStartup<Startup>();
                      })
                      .ConfigureAppConfiguration(configuration =>
                      {
                          configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                          configuration.AddUserSecrets<Program>();
                      })
                      .UseSerilog();
        }

        private static void ConfigureLogging()
        {

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithExceptionDetails()
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}