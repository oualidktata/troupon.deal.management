using System.Collections.Generic;
using System.Linq;
using Infra.DomainDrivenDesign.Base;
using Troupon.DealManagement.Core.Domain.Entities.Common;

namespace Troupon.DealManagement.Core.Domain.Entities.Deal
{
  public class DealOptionId : EntityId
  {
  }

  public class DealOption : Entity
  {
    public string Name { get; private set; }
    public virtual ICollection<DealPrice> Prices { get; private set; }

    public DealOption()
    {
      Prices = new List<DealPrice>();
    }

    public DealOption(
      string name) : this()
    {
      Name = name;
    }

    public DealPrice GetPrice(
      Currency currency)
    {
      return Prices.SingleOrDefault(x => x.Currency.CurrencyName == currency.CurrencyName);
    }

    public void SetPrice(
      DealPrice dealPrice)
    {
      var existingPriceWithSameCurrency = Prices.SingleOrDefault(x => x.Currency == dealPrice.Currency);

      if (existingPriceWithSameCurrency != null)
      {
        Prices.Remove(existingPriceWithSameCurrency);
      }

      Prices.Add(dealPrice);
    }

    public void SetPrices(
      ICollection<DealPrice> prices)
    {
      Prices = prices;
    }
  }
}
