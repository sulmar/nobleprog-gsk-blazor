using Domain.Models;
using FluentValidation;

namespace Domain.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(3);
        RuleFor(p => p.Description).MaximumLength(10);
        RuleFor(p => p.Account).Matches(@"\d*").WithMessage("Only digits");
        RuleFor(p => p.Password).Equal(p => p.ConfirmPassword);
    }

}
