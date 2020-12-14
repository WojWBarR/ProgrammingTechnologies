using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public void EditUser(User user)
        {
            userRepository.EditUser(user);
        }

        public List<User> GetAllUsers()
        {
            var users = userRepository.GetAllUsers().ToList();

            return users.Count == 0 ? null : users;
        }

        public User GetUser(int id)
        {
            var user = userRepository.GetUserById(id);

            if (user.Equals(null)) return null;

            return user;
        }
    }
}