using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Troupon.DealManagement.Api.HealthCheckers
{
  public class ErrorKPICheckProvider : IHealthCheck
  {
    private readonly string _baseUri;

    public ErrorKPICheckProvider(
      string baseUri)
    {
      _baseUri = baseUri;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
      HealthCheckContext context,
      CancellationToken cancellationToken = default)
    {
      //check the logs for how many Errors are there, this could be a search to ELK
      var random = new Random();
      int errors = random.Next(
        1,
        300);

      return errors switch
      {
        < 20 => Task.FromResult(HealthCheckResult.Healthy($"There were {errors} in the last 24H")),
        <= 50 => Task.FromResult(
          HealthCheckResult.Degraded($"There were {errors} in the last 24H,you may need to look at the logs ;)")),
        > 50 => Task.FromResult(
          HealthCheckResult.Unhealthy($"There were {errors} in the last 24H, you need investigate this!"))
      };
    }
  }
}
