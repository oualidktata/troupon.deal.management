using AutoMapper;
using Troupon.DealManagement.Core.Application.Commands;
using Troupon.DealManagement.Core.Domain.Entities.Deal;

namespace Troupon.DealManagement.Core.Application
{
  public class AutomapperProfileDomain : Profile
  {
    public AutomapperProfileDomain()
    {
      CreateMap<CreateDealCommand, Deal>();
    }
  }
}
