using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infra.DomainDrivenDesign.Base;
using Infra.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Troupon.DealManagement.Core.Domain.Entities.Deal;

namespace Troupon.DealManagement.Core.Application.Events
{
  public class DealCreatedEvent : INotification,
    IDomainEvent
  {
    public DealCreatedEvent()
    {
      CreationDate = DateTime.UtcNow;
    }

    public class DealCreatedEventHandler : INotificationHandler<DealCreatedEvent>
    {
      private readonly IReadRepository<Deal> _dealReadRepo;
      private readonly ILogger<DealCreatedEventHandler> _logger;

      public DealCreatedEventHandler(
        IReadRepository<Deal> readRepo,
        ILogger<DealCreatedEventHandler> logger)
      {
        Name = "DealCreatedEventHandler";
        _dealReadRepo = readRepo;
        _logger = logger;
      }

      public string Name { get; set; }

      public Task Handle(
        DealCreatedEvent notification,
        CancellationToken cancellationToken)
      {
        _logger.LogInformation($"{notification.GetType()} handled by {Name}");
        var allItems = _dealReadRepo.ToList();

        // throw new SomeBusinessException("DealCreatedEvent");
        //var duplicateItem = allItems.FirstOrDefault(i => i.Name == notification.NewName && i.Id != notification.Id);

        //if (duplicateItem != null)
        //{
        //    throw new DealAlreadyExistsException($"Deal already exists for: {duplicateItem.Id}");
        //}

        return Task.FromResult(allItems);
      }
    }

    public DateTime CreationDate { get; set; }
  }
}
