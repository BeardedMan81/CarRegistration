using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRegistration.Server.Hubs;
using CarRegistration.Server.Models;

namespace CarRegistration.Server.Services
{
    public class CarRegistrationCheckerService : BackgroundService
    {
        private readonly IHubContext<CarHub> _hubContext;
        private readonly CarDataService _carDataService;

        public CarRegistrationCheckerService(IHubContext<CarHub> hubContext, CarDataService carDataService)
        {
            _hubContext = hubContext;
            _carDataService = carDataService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var cars = _carDataService.GetCars();

                // Notify clients with the updated car list
                await _hubContext.Clients.All.SendAsync("ReceiveCarStatus", cars, stoppingToken);

                // Delay for periodic updates (e.g., every 10 seconds)
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}

