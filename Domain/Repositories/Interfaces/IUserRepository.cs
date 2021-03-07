using Domain.Models;

namespace Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        void Update(User user);
        User Create(User user);
        void Delete(User user);
    }
}