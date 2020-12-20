using System.Collections.Generic;
using System.Linq;
using Library.Data;

namespace Library.Logic
{
    public class UserService
    {
        private readonly LibraryDbContext _dbContext;

        public UserService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.OrderBy(x=>x.Name).ThenBy(x=>x.AmountOfBooksRented);
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(i => i.Id.Equals(id)).FirstOrDefault();
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

            _dbContext.Users.Add(addedUser);

            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var deletedUser = _dbContext.Users.FirstOrDefault(i => i.Id.Equals(id));

            if (deletedUser != null)
            {
                _dbContext.Users.Remove(deletedUser);
                _dbContext.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            var editedUser = _dbContext.Users.FirstOrDefault(b => b.Id.Equals(user.Id));

            if (editedUser != null)
            {
                editedUser.Name = user.Name;
                editedUser.Surname = user.Surname;
                editedUser.AmountOfBooksRented = user.AmountOfBooksRented;

                _dbContext.SaveChanges();
            }
        }
    }
}