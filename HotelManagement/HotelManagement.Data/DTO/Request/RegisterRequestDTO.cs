using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO.Request
{
    public class RegisterRequestDTO
    {
        public string name { get; set; }
        [Required(ErrorMessage = "Surname can not be null")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Surname must be between 3 and 30")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Username can not be null")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30")]
        public string username { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [EmailAddress(ErrorMessage = "Not Valid Email Format")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password can not be null")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 120")]
        public string password { get; set; }
        public bool enabled { get; set; }

        public ICollection<user_roles> user_Roles { get; set; }
    }
}
