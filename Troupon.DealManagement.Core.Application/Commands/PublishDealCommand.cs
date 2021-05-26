using System;
using MediatR;

namespace Troupon.DealManagement.Core.Application.Commands
{
  public class PublishDealCommand : IRequest<Unit>
  {
    public Guid DealId { get; set; }
  }
}
