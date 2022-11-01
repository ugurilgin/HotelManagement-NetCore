using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class user_roles
    {
        public int user_id { get; set; }
        public User user { get; set; }
        public int role_id { get; set; }
        public Roles role { get; set; }
    }
}
