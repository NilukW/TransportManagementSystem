using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IPassengerService : IUserService
    {
        Task<Passenger> AddPassenger(Passenger passenger);
    }
}
