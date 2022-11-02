using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class UserService : IUserService
    {
       private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User createUser(User user)
        {
            return _userRepository.createUser(user);
        }

        public void deleteUser(int id)
        {
            if (id > 0)
                _userRepository.deleteUser(id);
            else
                throw new Exception("Id can not be less than 1");
        }

        public List<User> getAllUsers()
        {
            return _userRepository.getAllUsers();
        }

        public User getUser(int id)
        {
            if (id > 0)
                return _userRepository.getUser(id);
            else
                throw new Exception("Id can not be less than 1");
        }

    

     
        public User updateUser(int id, User user)
        {
            if (id > 0)
            {
                return _userRepository.updateUser(user);
            }
            else
                throw new Exception("Id can not be less than 1");
        }
    }
}
