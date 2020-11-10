using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = userRepository.GetAllUsers();

            return users.Count == 0 ? null : users;
        }

        public User GetUser(int id)
        {
            User user = userRepository.GetUserById(id);

            if (user.Equals(null))
            {
                return null;
            }

            return user;
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

        public void EditUser(User user)
        {
            userRepository.EditUser(user);
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }
    }
}
