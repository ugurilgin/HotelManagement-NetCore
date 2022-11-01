using DataAccess.Abstract;
using Entities;
using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
     public class RoleRepository : IRoleRepository
    {
        public Roles createRole(Roles roles)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Roles.Add(roles);
                applicationDbContext.SaveChanges();
                return roles;
            }
        }
        public void deleteRole(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedRoles = getRole(id);
                applicationDbContext.Roles.Remove(deletedRoles);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Roles> getAllRoles()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Roles.ToList();
            }
        }

        public Roles getRole(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Roles.Find(id);
            }
        }

        public Roles updateRole(Roles roles)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Roles.Update(roles);
                applicationDbContext.SaveChanges();
                return roles;
            }
        }
    }
}
