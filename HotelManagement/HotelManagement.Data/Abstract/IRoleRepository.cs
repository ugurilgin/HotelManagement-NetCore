using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoleRepository
    {
        List<Roles> getAllRoles();
        Roles getRole(int id);
        Roles createRole(Roles roles);
        Roles updateRole(Roles roles);
        void deleteRole(int id);
    }
}
