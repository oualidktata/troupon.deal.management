using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infra.MediatR.Caching;
using Infra.Persistence.Repositories;
using MediatR;
using Troupon.DealManagement.Core.Application.Utility;
using Troupon.DealManagement.Core.Domain.Dtos;
using Troupon.DealManagement.Core.Domain.Entities.Deal;
using Troupon.DealManagement.Core.Domain.InputModels;

namespace Troupon.DealManagement.Core.Application.Queries.Deals
{
  public class GetDealsQuery : IRequest<IEnumerable<DealDto>>,
    ICachable
  {
    public string CacheKey { get; }

    public GetDealsQuery(
      SearchDealsFilter filter)
    {
      CacheKey = $"GetDeal-{UtilityMethods.ToHash(filter)}";
    }

    public class GetDealsQueryHandler : IRequestHandler<GetDealsQuery, IEnumerable<DealDto>>
    {
      private readonly IReadRepository<Deal> _dealReadRepo;

      private readonly IMapper _mapper;

      public GetDealsQueryHandler(
        IReadRepository<Deal> dealReadRepo,
        IMapper mapper)
      {
        _dealReadRepo = dealReadRepo;
        _mapper = mapper;
      }

      public async Task<IEnumerable<DealDto>> Handle(
        GetDealsQuery request,
        CancellationToken cancellationToken)
      {
        //Business logic goes here
        var deals = _dealReadRepo.ToList();
        var dealDtos =
          _mapper.Map<IEnumerable<Deal>, IEnumerable<DealDto>>(deals);

        return await Task.FromResult(dealDtos);
      }
    }
  }
}
