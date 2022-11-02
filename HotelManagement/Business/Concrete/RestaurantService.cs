using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class RestaurantService : IRestaurantService
    {
       private IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

 
        public Restaurant createMeal(Restaurant meal)
        {
            return _restaurantRepository.createMeal(meal);
        }



        public void deleteMeal(int id)
        {
            if (id > 0)
                _restaurantRepository.deleteMeal(id);
            else
                throw new Exception("Id can not be less than 1");
        }


        public List<Restaurant> getAllMeals()
        {
            return _restaurantRepository.getAllMeals();
        }


        public Restaurant getMeal(int id)
        {
            if (id > 0)
                return _restaurantRepository.getMeal(id);
            else
                throw new Exception("Id can not be less than 1");
        }

        public Restaurant updateMeal(int id , Restaurant meal)
        {
            if (id > 0) {
            return _restaurantRepository.updateMeal(meal); }
            else
                throw new Exception("Id can not be less than 1");
        }
    }
}
