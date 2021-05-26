using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Troupon.DealManagement.Api
{
  public class Program
  {
    public static void Main(
      string[] args)
    {
      var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
      Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

      try
      {
        Log.Information("App starting");
        CreateHostBuilder(args)
          .Build()
          .Run();
      }
      catch (System.Exception ex)
      {
        Log.Fatal(
          ex,
          "App failed to start");
      }
      finally
      {
        Log.CloseAndFlush();
      }
    }

    public static IHostBuilder CreateHostBuilder(
      string[] args) =>
      Host.CreateDefaultBuilder(args)
        .UseMetricsWebTracking()
        .UseMetrics(
          options =>
          {
            options.EndpointOptions = endpoints =>
            {
              endpoints.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
              endpoints.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
              endpoints.EnvironmentInfoEndpointEnabled = false;
            };
          })
        .ConfigureWebHostDefaults(
          webBuilder =>
          {
            webBuilder.UseStartup<Startup>()
              .UseSerilog();
          });
  }
}
