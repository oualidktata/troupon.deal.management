using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Troupon.DealManagement.Api.HealthCheckers;

namespace Troupon.DealManagement.Api.DependencyInjectionExtensions
{
  public static class AddHealthChecksExtensions
  {
    public static IServiceCollection AddHealthChecks(
      this IServiceCollection services,
      IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("mainDatabaseConnStr");
      var loggingBaseUri = configuration.GetValue<string>("Global:Dependencies:ElasticUri");
      var schedulerBaseUri = configuration.GetValue<string>("Global:Dependencies:SchedulerUri");
      services.AddSingleton<SchedulerCheckProvider>(new SchedulerCheckProvider(schedulerBaseUri));
      services.AddSingleton<ErrorKPICheckProvider>(new ErrorKPICheckProvider(loggingBaseUri));
      _ = services.AddHealthChecks()

        //preferred way: create a class for each custom checker
        .AddCheck<SchedulerCheckProvider>(
          "Scheduler",
          null,
          tags: new[] {"scheduler", "all", "external"})
        .AddCheck<ErrorKPICheckProvider>(
          "Errors KPI",
          null,
          tags: new[] {"Errors", "all", "internal"})
        .AddCheck(
          "Identity server",
          () => HealthCheckResult.Degraded("Not going well!"),
          tags: new[] {"external", "all"})
        .AddCheck(
          "Secure vault",
          () => HealthCheckResult.Healthy("All good!"),
          tags: new[] {"external", "all"})

        //Use specific extension for DBs or URI for sake of simplicity
        .AddSqlServer(
          connectionString,
          tags: new[] {"db", "internal", "all"},
          name: "Database")
        .AddUrlGroup(
          new System.Uri("https://www.google.ca"),
          tags: new[] {"uri", "all"},
          name: "Google")
        .AddUrlGroup(
          new System.Uri("https://www.yahoo.ca"),
          tags: new[] {"uri", "all"},
          name: "Yahoo!");

      return services;
    }

    public static IServiceCollection AddHealthChecksUI(
      this IServiceCollection services)
    {
      services.AddHealthChecksUI(
          setupSettings: setup =>
          {
            //https://localhost:5001/healthchecks-ui
            setup.SetHeaderText("My Health checkers");
            setup.SetApiMaxActiveRequests(1);
            setup.MaximumHistoryEntriesPerEndpoint(50);
            setup.SetEvaluationTimeInSeconds(5);

            //endpoints
            setup.AddHealthCheckEndpoint(
              "All",
              "/health");
            setup.AddHealthCheckEndpoint(
              "DataBases",
              "/health/db");
            setup.AddHealthCheckEndpoint(
              "Urls",
              "/health/uri");
            setup.AddHealthCheckEndpoint(
              "External Dependencies",
              "/health/external");
            setup.AddHealthCheckEndpoint(
              "Internal dependencies",
              "/health/internal");

            //|| check.Tags.Contains("all")
          })
        .AddInMemoryStorage();

      return services;
    }
  }
}
