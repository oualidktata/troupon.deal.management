using Infra.DomainDrivenDesign.Base;
using Troupon.DealManagement.Core.Domain.Entities.Common;

namespace Troupon.DealManagement.Core.Domain.Entities.Account
{
  public class BillingInfoId : EntityId
  {
  }

  public class BillingInfo : Entity
  {
    public virtual CreditCard CreditCard { get; private set; }
    public virtual Address Address { get; private set; }
  }
}
