using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Troupon.DealManagement.Api.ToMoveOrRemove
{
  public static class AddFluentValidatonExtensions
  {
    public static IServiceCollection AddFluentValidaton(
      this IServiceCollection services)
    {
      services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

      return services;
    }
  }
}
