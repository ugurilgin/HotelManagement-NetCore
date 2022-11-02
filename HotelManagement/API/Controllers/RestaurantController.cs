using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Error;
using Entities;
using HotelManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace API.Controllers
{
    [Route("api/meals")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]

        public IActionResult getAllMeals()
        {
            var meals = _restaurantService.getAllMeals();
            return Ok(meals);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getMeal(int id)
        {
            try { 
            var meal = _restaurantService.getMeal(id);
            if (meal != null)
            {
                return Ok(meal);
            }
            else
            {
                return StatusCode(404, ErrorManage.Show("Id not found"));
            }
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }

}

        [HttpPost]
        public IActionResult createMeal([FromBody] Restaurant meals)
        {
            try { 
            var createdMeal = _restaurantService.createMeal(meals);
            return CreatedAtAction("GET", new { createdMeal.id }, createdMeal);
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpPut("{id}")]
        public IActionResult updateMeal(int id,[FromBody] Restaurant meals )
        {
            try { 
            var updatedMeal = _restaurantService.updateMeal(id, meals);
            if (_restaurantService.getMeal(id) != null)
            {
                return Ok(updatedMeal);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpDelete("{id}")]
        public IActionResult deleteMeal(int id)
        {
            try { 
            if (_restaurantService.getMeal(id) != null)
            {
                _restaurantService.deleteMeal(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}
    }
}
