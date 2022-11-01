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
     public class ExtrasRepository : IExtrasRepository
    {
 
        public Extras createExtra(Extras extras)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Extras.Add(extras);
                applicationDbContext.SaveChanges();
                return extras;
            }
        }

        public void deleteExtra(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedExtra = getExtra(id);
                applicationDbContext.Extras.Remove(deletedExtra);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Extras> getAllExtras()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Extras.ToList();
            }
        }

        public Extras getExtra(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Extras.Find(id);
            }
        }

        public Extras updateExtra(Extras extras)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Extras.Update(extras);
                applicationDbContext.SaveChanges();
                return extras;
            }
        }

    }
}
