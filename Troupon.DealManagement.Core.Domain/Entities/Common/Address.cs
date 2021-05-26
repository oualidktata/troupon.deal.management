using System.Collections.Generic;
using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Common
{
  public class Address : ValueObject
  {
    public string StreetNumber { get; private set; }
    public string StreetLine1 { get; private set; }
    public string StreetLine2 { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }
    public string StateProvince { get; private set; }

    public Address(
      string streetNumber,
      string streetLine1,
      string streetLine2,
      string city,
      string country,
      string postalCode,
      string stateProvince)
    {
      StreetNumber = streetNumber;
      StreetLine1 = streetLine1;
      StreetLine2 = streetLine2;
      City = city;
      Country = country;
      PostalCode = postalCode;
      StateProvince = stateProvince;
    }

    protected override IEnumerable<object> GetEqualityValues()
    {
      yield return StreetNumber;
      yield return StreetLine1;
      yield return StreetLine2;
      yield return City;
      yield return Country;
      yield return PostalCode;
      yield return StateProvince;
    }
  }
}
