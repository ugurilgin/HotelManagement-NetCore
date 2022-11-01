using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Services
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Service Name can not be null")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Service Name must be between 3 and 25")]
        public string name { get; set; }
        [Required(ErrorMessage = "Price can not be null")]
        public int price { get; set; }

        public ICollection<customer_service> customer_Services { get; set; }
    }
}
