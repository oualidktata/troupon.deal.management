using Infra.DomainDrivenDesign.Base;

namespace Troupon.DealManagement.Core.Domain.Entities.Category
{
  public class DealCategoryId : EntityId
  {
  }

  public class DealCategory : AggregateRoot
  {
    public string Name { get; private set; }

    public DealCategory(
      string name)
    {
      Name = name;
    }

    public void SetName(
      string name)
    {
      Name = name;
    }
  }
}
