using System;
using System.Collections.Generic;
using Infra.oAuthService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Troupon.DealManagement.Api.Authentication
{
  public static class OAuthOpenApiExtensions
  {
    public static void AddOAuthSecurity(
      this Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions setup,
      OAuthSettings oAuthSettings)
    {
      var flows = new OpenApiOAuthFlows();
      flows.ClientCredentials = new OpenApiOAuthFlow()
      {
        TokenUrl = new Uri(
          oAuthSettings.TokenUrl,
          UriKind.Relative),
        Scopes = new Dictionary<string, string>()
        {
          {"custom_scope", "custom scope for CC defined in OKTA"},
        }
      };
      var oauthScheme = new OpenApiSecurityScheme()
      {
        Type = SecuritySchemeType.OAuth2,
        Description = "OAuth2 Description",
        Name = oAuthSettings.AuthHeaderName,
        In = ParameterLocation.Query,
        Flows = flows,
        Scheme = oAuthSettings.Scheme,
      };

      //securityrDefinition
      setup.AddSecurityDefinition(
        oAuthSettings.Scheme,
        oauthScheme);

      //securityrRequirements
      var securityrRequirements = new OpenApiSecurityRequirement();
      securityrRequirements.Add(
        oauthScheme,
        new List<string>() { });
      setup.AddSecurityRequirement(securityrRequirements);
    }
  }
}
