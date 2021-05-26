using Infra.DomainDrivenDesign.Base;
using Troupon.DealManagement.Core.Domain.Entities.Common;

namespace Troupon.DealManagement.Core.Domain.Entities.Account
{
  public class AccountId : EntityId
  {
  }

  public class Account : AggregateRoot
  {
    public string Name { get; private set; }
    public virtual Merchant.Merchant Merchant { get; private set; }
    public virtual BillingInfo BillingInfo { get; private set; }
    public virtual Location Location { get; private set; }
  }
}
