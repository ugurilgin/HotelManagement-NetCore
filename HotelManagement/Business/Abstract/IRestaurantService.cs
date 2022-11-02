using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRestaurantService
    {
        List<Restaurant> getAllMeals();
        Restaurant getMeal(int id);
        Restaurant createMeal(Restaurant meal);
        Restaurant updateMeal(int id,Restaurant meal);
        void deleteMeal(int id);
    }
}
