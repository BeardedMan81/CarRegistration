using CarRegistration.Server.Models;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRegistration.Server.Hubs
{
    public class CarHub : Hub
    {
        /// <summary>
        /// Sends a list of cars to all connected clients.
        /// </summary>
        /// <param name="cars">The updated list of cars.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task SendCarStatusAsync(List<Car> cars)
        {
            await Clients.All.SendAsync("ReceiveCarStatus", cars);
        }
    }
}
