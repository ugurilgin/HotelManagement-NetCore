using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class customer_restaurant
    {
        public int customer_id { get; set; }
        public Customers customers { get; set; }
        public int restaurant_id { get; set; }
        public Restaurant restaurant { get; set; }
    }
}
