using Dto.Responses;
using Dto.Requests;
using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        Response<User> GetById(int id);
        // Response<User> Edit(UserRequest request);
        // Response<User> Create(UserRequest request);
        // Response<User> Delete(int id);
    }
}