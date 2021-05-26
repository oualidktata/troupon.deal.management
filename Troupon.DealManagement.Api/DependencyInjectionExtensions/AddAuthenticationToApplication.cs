using Infra.oAuthService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Troupon.DealManagement.Api.Authentication;

namespace Troupon.DealManagement.Api.DependencyInjectionExtensions
{
  public static class AddAuthenticationExtensions
  {
    //public static IServiceCollection AddKeyCloackAuthenticationToApplication(this IServiceCollection services,IConfiguration configuration, IWebHostEnvironment env)
    //{

    //    var apiKeySettings = new OAuthSettings ();
    //    configuration.GetSection("Auth:KeyCloackProvider").Bind(apiKeySettings);

    //    services.AddScoped<IAuthService>(service => new KeyCloackAuthService(apiKeySettings));

    //    services.AddAuthentication(options =>
    //    {
    //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    //    }).AddScheme<TokenAuthenticationOptions, KeyCloackAuthenticationHandler>(apiKeySettings.Scheme,
    //                                     options => {
    //                                         options.ValidAudiences = apiKeySettings.Audiences;
    //                                         options.ValidIssuer = apiKeySettings.Issuer;
    //                                     });

    //    //    .AddJwtBearer(o =>
    //    //{
    //    //    o.Authority = configuration["Jwt:Authority"];
    //    //    o.Audience = configuration["Jwt:Audience"];
    //    //    o.RequireHttpsMetadata = false;

    //    //    o.Events = new JwtBearerEvents()
    //    //    {
    //    //        OnAuthenticationFailed = c =>
    //    //        {
    //    //            c.NoResult();

    //    //            c.Response.StatusCode = 500;
    //    //            c.Response.ContentType = "text/plain";

    //    //            if (env.IsDevelopment())
    //    //            {
    //    //                return c.Response.WriteAsync(c.Exception.ToString());
    //    //            }

    //    //            return c.Response.WriteAsync("An error occured processing your authentication with KeyCloak (RedHatSSO).");
    //    //        }
    //    //    };
    //    //});

    //    return services;
    //}
    public static IServiceCollection AddAuthenticationToApplication(
      this IServiceCollection services,
      IAuthService authenticationService,
      IConfiguration configuration,
      IWebHostEnvironment env)
    {
      services.AddAuthentication(
          options =>
          {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          })
        .AddScheme<TokenAuthenticationOptions, GenericAuthenticationHandler>(
          authenticationService.Settings.Scheme,
          options =>
          {
            options.ValidAudiences = authenticationService.Settings.Audiences;
            options.ValidIssuer = authenticationService.Settings.Issuer;
          });

      //    .AddJwtBearer(o =>
      //{
      //    o.Authority = configuration["Jwt:Authority"];
      //    o.Audience = configuration["Jwt:Audience"];
      //    o.RequireHttpsMetadata = false;

      //    o.Events = new JwtBearerEvents()
      //    {
      //        OnAuthenticationFailed = c =>
      //        {
      //            c.NoResult();

      //            c.Response.StatusCode = 500;
      //            c.Response.ContentType = "text/plain";

      //            if (env.IsDevelopment())
      //            {
      //                return c.Response.WriteAsync(c.Exception.ToString());
      //            }

      //            return c.Response.WriteAsync("An error occured processing your authentication with KeyCloak (RedHatSSO).");
      //        }
      //    };
      //});

      return services;
    }
  }
}
