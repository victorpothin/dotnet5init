using FluentValidation;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public IUserRepository _userRepository { get; }
        public UserValidator(IUserRepository userRepository)
        {
            this._userRepository = userRepository;

            RuleFor(user => user.Id)
                .Must(UserValid)
                .WithMessage("User Id not exists!");
            RuleFor(user => user.Name)
                .MinimumLength(3);
            RuleFor(user => user.FamilyName)
                .MinimumLength(2);
            RuleFor(user => user.Age)
                .ExclusiveBetween(0, 120);
        }

        private bool UserValid(int? id)
        {
            if(id == null)
                return true;
            var user = _userRepository.GetById(id.Value);
            return user != null;
        }
    }
}