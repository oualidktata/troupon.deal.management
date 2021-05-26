using System;
using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Merchant
{
  public class MerchantId : EntityId
  {
    public MerchantId()
    {
    }

    public MerchantId(
      string id) : base(id)
    {
    }

    public MerchantId(
      Guid guid) : base(guid)
    {
    }
  }

  public class Merchant : AggregateRoot
  {
    public string Name { get; private set; }
    public string Website { get; private set; }
  }
}
