using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class customer_extra
    {
       

        public int customer_id { get; set; }
        public Customers customers { get; set; }
        public int extras_id { get; set; }
        public Extras extras { get; set; }
        

    }
}
