using System.Collections.Generic;
using System.Linq;
using Library.Data.Interfaces;
using Library.Data.Models;

namespace Library.Logic.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private readonly MockDbContext dbContext;

        public MockUserRepository(MockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> GetAllUsers()
        {
            return dbContext.Users();
        }

        public User GetUserById(int id)
        {
            return dbContext.Users().FirstOrDefault(i => i.Id.Equals(id));
        }

        public void DeleteUser(int id)
        {
            var deletedUser = dbContext.Users().FirstOrDefault(i => i.Id.Equals(id));

            if (deletedUser != null) dbContext.Users().Remove(deletedUser);
        }

        public void EditUser(User user)
        {
            var editedUser = dbContext.Users().FirstOrDefault(b => b.Id.Equals(user.Id));

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

            dbContext.Users().Add(addedUser);
        }
    }
}