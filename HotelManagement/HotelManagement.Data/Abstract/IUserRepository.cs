using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRepository
    {
        List<User> getAllUsers();
        User getUser(int id);
        User createUser(User user);
        User updateUser(User user);
        void deleteUser(int id);
    }
}
