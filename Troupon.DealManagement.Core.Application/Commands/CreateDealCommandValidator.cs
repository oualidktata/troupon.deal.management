using FluentValidation;

namespace Troupon.DealManagement.Core.Application.Commands
{
  class CreateDealCommandValidator : AbstractValidator<CreateDealCommand>
  {
    public CreateDealCommandValidator()
    {
      RuleFor(c => c.Description)
        .NotEmpty();
      RuleFor(c => c.Title)
        .NotEmpty();
      RuleFor(c => c.ExpirationDate)
        .NotEmpty();
    }
  }
}
