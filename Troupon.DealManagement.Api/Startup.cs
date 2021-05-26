using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Infra.oAuthService;
using Infra.Persistence.EntityFramework.Extensions;
using Infra.Persistence.SqlServer.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Troupon.DealManagement.Api.DependencyInjectionExtensions;
using Troupon.DealManagement.Core.Application;
using Troupon.DealManagement.Infra.Persistence;

namespace Troupon.DealManagement.Api
{
  public class Startup
  {
    public Startup(
      IConfiguration configuration,
      IWebHostEnvironment hostEnvironment)
    {
      Configuration = configuration;
      HostEnvironment = hostEnvironment;
    }

    private IConfiguration Configuration { get; }
    private IWebHostEnvironment HostEnvironment { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(
      IServiceCollection services)
    {
      var apiKeySettings = new OAuthSettings();
      Configuration.GetSection($"Auth:{Configuration.GetValue<string>("Auth:DefaultAuthProvider")}")
        .Bind(apiKeySettings);
      services.AddScoped<IAuthService>(service => new AuthService(apiKeySettings));

      services.AddAuthenticationToApplication(
        new AuthService(apiKeySettings),
        Configuration,
        HostEnvironment);
      services.AddAuthorization(
        options =>
        {
          //options.AddPolicy("crm-api-backend", policy => policy.RequireClaim("crm-api-backend", "[crm-api-backend]"));
        });

      services.AddAutoMapper(
        typeof(AutomapperProfile),
        typeof(AutomapperProfileDomain));

      services.AddMediator();
      services.AddSqlServerPersistence<DealManagementDbContext>(
        Configuration,
        "mainDatabaseConnStr",
        Assembly.GetExecutingAssembly()
          .GetName()
          .Name);
      services.AddQueries();
      services.AddEfReadRepository<DealManagementDbContext>();
      services.AddEfWriteRepository<DealManagementDbContext>();
      services.AddGraphQl(); //https://localhost:5001/graphql/
      services.AddControllers();
      services.AddOpenApi(Configuration);
      services.AddHealthChecks(Configuration);
      services.AddHealthChecksUI();
      services.AddMetrics();
      services.AddFluentValidaton();
      services.AddMemoryCache();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app,
      IWebHostEnvironment env,
      IDbContextFactory<DealManagementDbContext> dbContextFactory)
    {
      //if (env.IsDevelopment())
      //{
      //    app.UseDeveloperExceptionPage();
      //}
      app.UseExceptionHandler("/error");

      app.UseHttpsRedirection();
      app.UseSerilogRequestLogging();

      // app.UsePathBase("/graphql");

      //catalogDbContext.Database.EnsureDeleted();
      var catalogDbContext = dbContextFactory.CreateDbContext();
      catalogDbContext.Database.Migrate();

      // app.UsePlayground();

      app.UseSwagger();
      app.UseSwaggerUI(
        c =>
        {
          c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Troupon Deal Management");
          c.RoutePrefix = string.Empty;
        });
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(
        endpoints =>
        {
          endpoints.MapControllers();
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

          //endpoints.MapHealthChecks("/health/scheduler", new HealthCheckOptions() { Predicate = (check) => check.Tags.Contains("scheduler"), ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
          endpoints.MapHealthChecksUI();
          endpoints.MapGraphQL();
        });
    }

    private async Task JsonHealthReport(
      HttpContext context,
      HealthReport report)
    {
      context.Response.ContentType = "application/json";
      await JsonSerializer.SerializeAsync(
        context.Response.Body,
        new {Status = report.Status.ToString()},
        new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
    }
  }
}
