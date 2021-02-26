using FluentValidation;
using Domain.Models;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .MinimumLength(3);
            RuleFor(user => user.FamilyName)
                .MinimumLength(2);
            RuleFor(user => user.Age)
                .ExclusiveBetween(0, 120);
        }
    }
}