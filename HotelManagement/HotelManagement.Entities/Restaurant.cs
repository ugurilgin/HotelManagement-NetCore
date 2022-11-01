using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Restaurant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Meal Name can not be null")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Meal Name must be between 3 and 25")]
        public string name { get; set; }
        [Required(ErrorMessage = "Price can not be null")]
        public int price { get; set; }
        public ICollection<customer_restaurant> customer_Restaurants { get; set; }
    }
}
