using System;
using System.Collections.Generic;
using System.Linq;
using Infra.DomainDrivenDesign.Base;
using Troupon.DealManagement.Core.Domain.Entities.Category;
using Troupon.DealManagement.Core.Domain.Entities.Common;
using Troupon.DealManagement.Core.Domain.Enums;

namespace Troupon.DealManagement.Core.Domain.Entities.Deal
{
  public class DealId : EntityId
  {
    public DealId()
    {
    }

    public DealId(
      string id) : base(id)
    {
    }

    public DealId(
      Guid guid) : base(guid)
    {
    }
  }

  public class Deal : AggregateRoot
  {
    public string Description { get; private set; }
    public string Title { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public int Limitation { get; private set; }
    public string OtherConditions { get; private set; }
    public DealStatus Status { get; private set; }
    public virtual Account.Account Account { get; private set; }
    public virtual ICollection<DealOption> Options { get; private set; }
    public virtual ICollection<DealCategory> Categories { get; private set; }

    public Deal()
    {
      Options = new List<DealOption>();
      Categories = new List<DealCategory>();
    }

    public void Publish()
    {
      // Do Some Stuff and Validation
      if (!CanPublish()) return;
      Status = DealStatus.Published;
    }

    public bool CanPublish()
    {
      // Do other validations
      return Status == DealStatus.Draft;
    }

    public void End()
    {
      Status = DealStatus.Ended;
    }

    public bool CanEnd()
    {
      return Status == DealStatus.Published;
    }

    public void SetDealOptions(
      ICollection<DealOption> options)
    {
      Options = options;
    }

    public void AddDealOption(
      DealOption option)
    {
      Options.Add(option);
    }

    public void SetCategories(
      ICollection<DealCategory> categories)
    {
      Categories = categories;
    }

    public void AddCategory(
      DealCategory category)
    {
      Categories.Add(category);
    }

    public DealOption GetOption(
      Guid optionId)
    {
      return Options.SingleOrDefault(x => x.Id == optionId);
    }

    public DealPrice GetOptionPrice(
      Guid optionId,
      Currency currency)
    {
      var option = GetOption(optionId);

      if (option == null) return null;

      return option.GetPrice(currency);
    }
  }
}
