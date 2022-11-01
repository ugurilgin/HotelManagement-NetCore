using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum ERole
    {
        ROLE_USER,
        ROLE_MODERATOR,
        ROLE_ADMIN
    }
    public class Roles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        public ERole name { get; set; }

        public ICollection<user_roles> user_Roles { get; set; }


    }
}
