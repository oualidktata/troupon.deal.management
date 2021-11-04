using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Troupon.DealManagement.Api.ToMoveOrRemove.HealthCheckers
{
  public class SchedulerCheckProvider : IHealthCheck
  {
    private readonly string baseUri;

    public SchedulerCheckProvider(string baseUri)
    {
      this.baseUri = baseUri;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
      return Task.FromResult(HealthCheckResult.Healthy("The scheduling service is UP!"));
    }
  }
}
