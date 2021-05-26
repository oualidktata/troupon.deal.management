using AutoMapper;
using Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Troupon.DealManagement.Api.Schema;
using Troupon.DealManagement.Core.Domain.Entities.Merchant;

namespace Troupon.DealManagement.Api.DependencyInjectionExtensions
{
  public static class AddQueriesExtensions
  {
    public static IServiceCollection AddQueries(
      this IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<MerchantQueries>(
        provider => new MerchantQueries(
          provider.GetRequiredService<IReadRepository<Merchant>>(),
          provider.GetRequiredService<IMapper>()));

      /*serviceCollection.AddScoped<DealQueries>(
          provider => new DealQueries(provider.GetRequiredService<IReadRepository<Deal>>()));*/

      return serviceCollection;
    }
  }
}
