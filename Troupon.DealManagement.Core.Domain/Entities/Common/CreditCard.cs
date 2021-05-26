using System;
using System.Collections.Generic;
using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Common
{
  public class CreditCard : ValueObject
  {
    public string Number { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public string Cvv { get; private set; }

    public CreditCard(
      string number,
      DateTime expirationDate,
      string cvv)
    {
      Number = number;
      ExpirationDate = expirationDate;
      Cvv = cvv;
    }

    protected override IEnumerable<object> GetEqualityValues()
    {
      yield return Number;
      yield return ExpirationDate;
      yield return Cvv;
    }
  }
}
