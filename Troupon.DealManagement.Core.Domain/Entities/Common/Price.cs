using System.Collections.Generic;
using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Common
{
  public class Price : ValueObject
  {
    public float Amount { get; private set; }
    public virtual Currency Currency { get; private set; }

    public Price()
    {
    }

    public Price(
      float amount,
      Currency currency)
    {
      Amount = amount;
      Currency = currency;
    }

    protected override IEnumerable<object> GetEqualityValues()
    {
      yield return Currency;
      yield return Amount;
    }
  }
}
