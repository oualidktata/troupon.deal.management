using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Infra.Persistence.Repositories;
using MediatR;
using Troupon.DealManagement.Core.Domain.Dtos;
using Troupon.DealManagement.Core.Domain.Entities.Deal;

namespace Troupon.DealManagement.Core.Application.Queries.Deals
{
  public class GetOneDealQuery : IRequest<DealDto>
  {
    public Guid Id { get; set; }

    public class GetOneDealQueryHandler : IRequestHandler<GetOneDealQuery, DealDto>
    {
      private readonly IReadRepository<Deal> _dealReadRepo;

      private readonly IMapper _mapper;

      public GetOneDealQueryHandler(
        IReadRepository<Deal> dealReadRepo,
        IMapper mapper)
      {
        _dealReadRepo = dealReadRepo;
        _mapper = mapper;
      }

      public async Task<DealDto> Handle(
        GetOneDealQuery request,
        CancellationToken cancellationToken)
      {
        //Business logic goes here
        var deal = _dealReadRepo.SingleOrDefault(x => x.Id == request.Id);
        var dealDto = _mapper.Map<Deal, DealDto>(deal);

        return await Task.FromResult(dealDto);
      }
    }
  }
}
