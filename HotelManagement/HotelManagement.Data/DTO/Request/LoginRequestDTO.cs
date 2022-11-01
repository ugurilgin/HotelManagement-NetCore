using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO.Request
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "Name can not be null")]
        private string username { get; set; }
        private string password { get; set; }
    }
}
