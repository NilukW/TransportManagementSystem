using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUserRepository _userRepository;

        public DriverService(IUserRepository userRepository,IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
            _userRepository = userRepository;
        }
        public async Task<int> CreateDriver(Driver driver)
        {
            driver.UserId = await _userRepository.AddAsync(driver as User);
            await _driverRepository.AddAsync(driver);
            return driver.UserId;
        }

        public Task<int> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            return await _driverRepository.GetAllAsync();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Driver> GetDriver(int id)
        {
            return await _driverRepository.GetByIdAsync(id);
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
