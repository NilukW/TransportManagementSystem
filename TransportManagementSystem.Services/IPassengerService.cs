using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IPassengerService : IUserService
    {
        Task<int> AddPassenger(Passenger passenger);
        Task<List<Passenger>> GetAllPassengers();
        Task<Passenger> GetPassenger(int id);
    }
}
