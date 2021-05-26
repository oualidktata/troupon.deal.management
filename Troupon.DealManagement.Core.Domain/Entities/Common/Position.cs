using System.Collections.Generic;
using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Common
{
  public class Position : ValueObject
  {
    public string Longitude { get; private set; }
    public string Latitude { get; private set; }

    public Position(
      string longitude,
      string latitude)
    {
      Longitude = longitude;
      Latitude = latitude;
    }

    protected override IEnumerable<object> GetEqualityValues()
    {
      yield return Longitude;
      yield return Latitude;
    }
  }
}
