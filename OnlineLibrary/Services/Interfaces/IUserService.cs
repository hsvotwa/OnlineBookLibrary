using OnlineLibrary.Models;
using System.Collections.Generic;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
    }
}
