using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void DeleteUser(int id);
        void EditUser(User user);
        void AddUser(User user);
    }
}
