using System;
using System.Linq;
using AutoMapper;
using HotChocolate.Data;
using Infra.Persistence.Repositories;
using Troupon.DealManagement.Core.Domain.Dtos;
using Troupon.DealManagement.Core.Domain.Entities.Merchant;

namespace Troupon.DealManagement.Api.Schema
{
  //[ExtendObjectType(Name = "Query")]
  public class MerchantQueries
  {
    private readonly IReadRepository<Merchant> _merchantReadRepo;
    private readonly IMapper _mapper;

    public MerchantQueries(
      IReadRepository<Merchant> merchantReadRepo,
      IMapper mapper)
    {
      _merchantReadRepo = merchantReadRepo;
      _mapper = mapper;
    }

    public MerchantDto GetMerchant(
      Guid appId)
    {
      var merchant = _merchantReadRepo.FirstOrDefault(x => x.Id == appId);

      return _mapper.Map<Merchant, MerchantDto>(merchant);
    }

    public MerchantDto GetOneMerchant()
    {
      return new MerchantDto {Name = "Sample App", Id = Guid.NewGuid(), Website = "www.merchant.com"};
    }

    ////[UseDbContext(typeof(CatalogDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<MerchantDto> GetMerchants()
    {
      //return new List<MerchantDto>() { new MerchantDto { Name = "Sample App 1", Id = Guid.NewGuid(), Description = "description" },
      //new MerchantDto { Name = "Sample App 2", Id = Guid.NewGuid(), Description = "description" },
      //new MerchantDto { Name = "Sample App 3", Id = Guid.NewGuid(), Description = "description" }}.AsQueryable();
      return _merchantReadRepo.AsQueryable()
        .Select(x => _mapper.Map<MerchantDto>(x));
    }
  }
}
