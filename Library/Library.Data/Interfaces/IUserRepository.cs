using System.Collections.Generic;

namespace Library.Data
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