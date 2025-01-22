using Microsoft.AspNetCore.Mvc;
using CarRegistration.Server.Models;
using System.Collections.Generic;
using CarRegistration.Server.Services;
using System.Text.Json;

namespace CarRegistration.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarDataService _carDataService;

        public CarController(CarDataService carDataService)
        {
            _carDataService = carDataService;
        }

        /// <summary>
        /// Get a list of cars with an optional make filter.
        /// </summary>
        /// <param name="make">The make of the car to filter by (optional).</param>
        /// <returns>A list of cars.</returns>
        [HttpGet]
        public IActionResult GetCars([FromQuery] string? make = null)
        {
            var cars = _carDataService.GetCars();

            if (!string.IsNullOrEmpty(make))
            {
                var filteredCars = cars.FindAll(car => car.Make.Equals(make, StringComparison.OrdinalIgnoreCase));
                return Ok(filteredCars);
            }

            return Ok(cars);
        }

    }   
}
