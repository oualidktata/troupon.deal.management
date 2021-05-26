using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Troupon.DealManagement.Core.Application.Events;

namespace Troupon.DealManagement.Core.Application.Handlers.Events
{
  public class DealPublishedEventHandler : INotificationHandler<DealPublishedEvent>
  {
    public DealPublishedEventHandler()
    {
    }

    public Task Handle(
      DealPublishedEvent notification,
      CancellationToken cancellationToken)
    {
      // Trigger another command

      return Task.CompletedTask;
    }
  }
}
