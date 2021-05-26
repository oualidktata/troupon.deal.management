using System.Collections.Generic;
using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Common
{
  public class Location : ValueObject
  {
    public virtual Position Position { get; private set; }
    public virtual Address Address { get; private set; }

    public Location()
    {
    }

    public Location(
      Position position,
      Address address)
    {
      Position = position;
      Address = address;
    }

    protected override IEnumerable<object> GetEqualityValues()
    {
      yield return Position;
      yield return Address;
    }
  }
}
