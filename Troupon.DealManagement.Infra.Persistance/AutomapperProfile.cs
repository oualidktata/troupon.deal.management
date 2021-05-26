using AutoMapper;
using Troupon.DealManagement.Core.Domain.Dtos;
using Troupon.DealManagement.Core.Domain.Entities.Deal;
using Troupon.DealManagement.Core.Domain.Entities.Merchant;

namespace Troupon.DealManagement.Infra.Persistence
{
  public class AutomapperProfile : Profile
  {
    public AutomapperProfile()
    {
      CreateMap<Deal, DealDto>()
        .ForMember(
          x => x.MerchantName,
          opt => opt.MapFrom(src => src.Account.Merchant.Name));
      CreateMap<Merchant, MerchantDto>();
    }
  }
}
