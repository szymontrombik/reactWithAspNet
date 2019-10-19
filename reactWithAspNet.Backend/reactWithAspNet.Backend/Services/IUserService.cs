using System.Collections.Generic;
using reactWithAspNet.Backend.Models;

namespace reactWithAspNet.Backend.Services
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        User Create(User newUser);

        void Update(int id, User updatedUser);

        void Delete(int id);
    }
}
