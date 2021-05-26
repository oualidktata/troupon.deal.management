using System;
using Infra.DomainDrivenDesign.Base;
using MediatR;

namespace Troupon.DealManagement.Core.Application.Events
{
  public class DealPublishedEvent : INotification,
    IDomainEvent
  {
    public DateTime CreationDate { get; set; }

    public DealPublishedEvent()
    {
      CreationDate = DateTime.UtcNow;
    }
  }
}
