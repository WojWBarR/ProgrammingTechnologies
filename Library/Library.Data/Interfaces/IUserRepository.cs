using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(int id);
        void EditUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
