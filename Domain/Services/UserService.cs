using Domain.Services.Interfaces;
using Domain.Repositories.Interfaces;
using Dto.Requests;
using Dto.Responses;
using static System.String;
using System.Linq;
using System.Collections.Generic;
using FluentValidation.Results;
using Domain.Models;
using Domain.Validators;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository { get; }
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public Response<User> GetById(int id)
        {
            var user =  this._userRepository.GetById(id);
            var res = new Response<User>()
            {
                Succeeded = (user != null),
                Data = user
            };
            return res;
        }
        
        public Response<User> Edit(UserRequest request)
        {
            User user = new User
            {
                Id = request.Id,
                Name = request.Name,
                FamilyName = request.FamilyName,
                Age = request.Age
            };
            var response = Validate(user);
            if(response.Succeeded)
                _userRepository.Update(user);
            return response;          
        }

        // public Response<User> Create(UserRequest request)
        // {

        // }
        
        // public Response<User> Delete(int id)
        // {

        // }

        private string FormatErrors(IList<ValidationFailure> errors)
        {
            IEnumerable<string> errorsMessages = errors.Select(error => error.ErrorMessage);
            return Join(", ", errorsMessages);
        }

        private Response<User> Validate(User user)
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(user);
            Response<User> response = new Response<User>()
            {
                Data = user,
                Succeeded = result.IsValid,
                Errors = FormatErrors(result.Errors)
            };
            return response;
        }
    }
}