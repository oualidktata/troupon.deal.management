using System.Collections.Generic;
using Infra.oAuthService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Troupon.DealManagement.Api.Authentication
{
  public static class BearerOpenApiExtensions
  {
    public static void AddBearerAuthentication(
      this Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions setup,
      IOAuthSettings oAuthSettings)
    {
      setup.AddSecurityDefinition(
        oAuthSettings.Scheme,
        new OpenApiSecurityScheme
        {
          Type = SecuritySchemeType.Http,
          Name = oAuthSettings.AuthHeaderName,
          In = ParameterLocation.Header,
          BearerFormat = "JWT",
          Scheme = oAuthSettings.Scheme,
          Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
        });

      setup.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = oAuthSettings.Scheme
              }
            },
            new List<string>()
          }
        });
    }
  }
}
