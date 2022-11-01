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
     public class RestaurantRepository : IRestaurantRepository
    {
 
        public Restaurant createMeal(Restaurant meal)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Restaurants.Add(meal);
                applicationDbContext.SaveChanges();
                return meal;
            }
        }

        public void deleteMeal(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedMeal = getMeal(id);
                applicationDbContext.Restaurants.Remove(deletedMeal);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Restaurant> getAllMeals()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Restaurants.ToList();
            }
        }

        public Restaurant getMeal(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Restaurants.Find(id);
            }
        }

        public Restaurant updateMeal(Restaurant meal)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Restaurants.Update(meal);
                applicationDbContext.SaveChanges();
                return meal;
            }
        }
    }
}
