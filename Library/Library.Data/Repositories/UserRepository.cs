using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<User> GetAllUsers()
        {
            return _dataContext.Users;
        }

        public User GetUserById(int id)
        {
            return _dataContext.Users.FirstOrDefault(i => i.Id.Equals(id));
        }

        public void DeleteUser(int id)
        {
            var deletedUser = _dataContext.Users.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedUser != null) _dataContext.Users.Remove(deletedUser);
        }

        public void EditUser(User user)
        {
            var editedUser = _dataContext.Users.FirstOrDefault(b => b.Id.Equals(user.Id));

            if (editedUser != null)
            {
                editedUser.Id = user.Id;
                editedUser.Name = user.Name;
                editedUser.Surname = user.Surname;
                editedUser.AmountOfBooksRented = user.AmountOfBooksRented;
            }
        }

        public void AddUser(User user)
        {
            var addedUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                AmountOfBooksRented = user.AmountOfBooksRented
            };

            _dataContext.Users.Add(addedUser);
        }
    }
}