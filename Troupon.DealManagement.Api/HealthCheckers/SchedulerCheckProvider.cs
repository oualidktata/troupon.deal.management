using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Troupon.DealManagement.Api.HealthCheckers
{
  public class SchedulerCheckProvider : IHealthCheck
  {
    private readonly string _baseUri;

    public SchedulerCheckProvider(
      string baseUri)
    {
      _baseUri = baseUri;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
      HealthCheckContext context,
      CancellationToken cancellationToken = default)
    {
      //check db Connection
      return Task.FromResult(HealthCheckResult.Healthy("The scheduling service is UP!"));
    }
  }
}
