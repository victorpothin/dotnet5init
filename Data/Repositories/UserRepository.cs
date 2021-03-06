using Domain.Repositories.Interfaces;
using Domain.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public User GetById(int id)
      {
	      return userContext.Users.FirstOrDefault(user => user.Id == id);
      }

      public void Update(User user)
      {
	      userContext.Update(user);
	      userContext.SaveChanges();
      }

      public User Create(User user)
      {
	      EntityEntry<User> result = userContext.Add(user);
	      userContext.SaveChanges();
	      return result.Entity;
      }

      public void Delete(User user)
      {
	      userContext.Remove(user);
	      userContext.SaveChanges();
      }   
    }
}