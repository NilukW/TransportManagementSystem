using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IUserRepository _userRepository;
        public PassengerService(IUserRepository userRepository, IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
            _userRepository = userRepository;
        }
        public async Task<int> AddPassenger(Passenger passenger)
        {
            passenger.UserId = await _userRepository.AddAsync(passenger as User);
            return await _passengerRepository.AddAsync(passenger);
        }

        public async Task<List<Passenger>> GetAllPassengers()
        {
            return await _passengerRepository.GetAllAsync();
        }

        public async Task<Passenger> GetPassenger(int id)
        {
            return await _passengerRepository.GetByIdAsync(id);
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
