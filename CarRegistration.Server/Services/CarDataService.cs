using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CarRegistration.Server.Models;

namespace CarRegistration.Server.Services
{
    public class CarDataService
    {
        private readonly string _dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cars.json");

        /// <summary>
        /// Load car data from the JSON file.
        /// </summary>
        /// <returns>A list of cars.</returns>
        public List<Car> GetCars()
        {
            if (!File.Exists(_dataFilePath))
            {
                return new List<Car>();
            }

            var jsonData = File.ReadAllText(_dataFilePath);
            return JsonSerializer.Deserialize<List<Car>>(jsonData) ?? new List<Car>();
        }
    }
}
