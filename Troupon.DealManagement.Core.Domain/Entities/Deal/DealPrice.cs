using System.Collections.Generic;
using Infra.DomainDrivenDesign.Base;
using Troupon.DealManagement.Core.Domain.Entities.Common;

namespace Troupon.DealManagement.Core.Domain.Entities.Deal
{
  public class DealPrice : ValueObject
  {
    public virtual Currency Currency { get; private set; }
    public virtual Price OriginalPrice { get; private set; }
    public virtual Price CurrentPrice { get; private set; }

    public DealPrice()
    {
    }

    public DealPrice(
      Currency currency,
      Price originalPrice,
      Price currentPrice)
    {
      Currency = currency;
      OriginalPrice = originalPrice;
      CurrentPrice = currentPrice;
    }

    protected override IEnumerable<object> GetEqualityValues()
    {
      yield return Currency;
      yield return OriginalPrice;
      yield return CurrentPrice;
    }
  }
}
