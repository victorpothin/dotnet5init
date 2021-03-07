using Domain.Services.Interfaces;
using Domain.Repositories.Interfaces;
using Dto.Requests;
using Dto.Responses;
using static System.String;
using System.Linq;
using System.Collections.Generic;
using FluentValidation.Results;
using Domain.Models;

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
        
        // public Response<User> Edit(UserRequest request)
        // {
        //     User user = GetById(request.Id);
        //     if(user == null)
        //     {
        //         return new Response<User>(){
        //             Succeeded = false,

        //         };
        //     }
        // }

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
    }
}