using System.Reflection;
using HealthChecks.UI.Client;
using Infra.Api.DependencyInjection;
using Infra.Authorization.Policies;
using Infra.MediatR;
using Infra.OAuth.Controllers.DependencyInjection;
using Infra.OAuth.DependencyInjection;
using Infra.Persistence.EntityFramework.Extensions;
using Infra.Persistence.SqlServer.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Troupon.Catalog.Api.DependencyInjectionExtensions;
using Troupon.DealManagement.Api.ToMoveOrRemove;
using Troupon.DealManagement.Core.Application;
using Troupon.DealManagement.Core.Application.Queries.Deals;
using Troupon.DealManagement.Infra.Persistence;

namespace Troupon.DealManagement.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddOAuthGenericAuthentication(Configuration).AddOAuthM2MAuthFlow();

      services.AddControllers().AddNewtonsoftJson();
      services.AddOAuthController();

      services.AddAuthorization(options =>
      {
        options.AddPolicy(TenantPolicy.Key, pb => pb.AddTenantPolicy("pwc"));
        options.AddPolicy(AdminOnlyPolicy.Key, pb => pb.AddAdminOnlyPolicy());
      });

      services.AddPolicyHandlers();

      services.AddAutoMapper(typeof(AutomapperProfile).Assembly, typeof(AutomapperProfileDomain).Assembly);

      services.AddMediator(typeof(GetDealsQuery).Assembly);
      services.AddSqlServerPersistence<DealsDbContext>(Configuration, "mainDatabaseConnStr", Assembly.GetExecutingAssembly());

      services.AddEfReadRepository<DealsDbContext>();
      services.AddEfWriteRepository<DealsDbContext>();
      services.AddOpenApi(Assembly.GetExecutingAssembly());
      services.AddMetrics();
      services.AddMemoryCache();

      services.Configure<MvcOptions>(opt =>
      {
        opt.Filters.Add(new ProducesAttribute("application/json", "application/xml"));
        opt.Filters.Add(new ConsumesAttribute("application/json", "application/xml"));
      });

      services.AddPwcApiBehaviour();

      // TO MOVE ?
      services.AddHealthChecks(Configuration);
      services.AddHealthChecksUI();
      services.AddFluentValidaton();
    }

    public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider, IDbContextFactory<DealsDbContext> dbContextFactory)
    {
      var dealsDbContext = dbContextFactory.CreateDbContext();
      dealsDbContext.Database.Migrate();

      app.UseExceptionHandler("/error");
      app.UseHttpsRedirection();
      app.UseSerilogRequestLogging();

      app.UseSwagger();
      app.ConfigureSwaggerUI(apiVersionDescriptionProvider);

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        ConfigureHealthChecks(endpoints);
        endpoints.MapGraphQL();
      });
    }

    private void ConfigureHealthChecks(IEndpointRouteBuilder endpoints)
    {
      endpoints.MapHealthChecks(
            "/health",
            new HealthCheckOptions()
            {
              Predicate = (
                check) => check.Tags.Contains("all"),
              ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
      endpoints.MapHealthChecks(
        "/health/external",
        new HealthCheckOptions()
        {
          Predicate = (
            check) => check.Tags.Contains("external"),
          ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
      endpoints.MapHealthChecks(
        "/health/db",
        new HealthCheckOptions()
        {
          Predicate = (
            check) => check.Tags.Contains("db"),
          ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
      endpoints.MapHealthChecks(
        "/health/uri",
        new HealthCheckOptions()
        {
          Predicate = (
            check) => check.Tags.Contains("uri"),
          ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
      endpoints.MapHealthChecks(
        "/health/internal",
        new HealthCheckOptions()
        {
          Predicate = (
            check) => check.Tags.Contains("errors") || check.Tags.Contains("db"),
          ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

      endpoints.MapHealthChecksUI();
    }
  }
}
