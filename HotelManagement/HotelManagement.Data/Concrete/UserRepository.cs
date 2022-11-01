using DataAccess.Abstract;
using Entities;
using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
     public class UserRepository : IUserRepository
    {
        public User createUser(User user)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Users.Add(user);
                applicationDbContext.SaveChanges();
                return user;
            }
        }
        public void deleteUser(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedUser = getUser(id);
                applicationDbContext.Users.Remove(deletedUser);
                applicationDbContext.SaveChanges();
            }
        }

        public List<User> getAllUsers()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Users.ToList();
            }
        }

        public User getUser(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Users.Find(id);
            }
        }
        public User updateUser(User user)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Users.Update(user);
                applicationDbContext.SaveChanges();
                return user;
            }
        }
    }
}
