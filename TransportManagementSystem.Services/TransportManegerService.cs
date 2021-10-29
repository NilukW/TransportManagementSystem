using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class TransportManagerService : ITransportManagerService
    {
        private readonly ITransportManagerRepository _transportManagerRepository;
        private readonly IUserRepository _userRepository;

        public TransportManagerService(IUserRepository userRepository, ITransportManagerRepository transportManagerRepository)
        {
            _transportManagerRepository = transportManagerRepository;
            _userRepository = userRepository;
        }

        public async Task<int> CreateTransportManager(TransportManager transportManager)
        {
            transportManager.UserId = await _userRepository.AddAsync(transportManager as User);
            return await _transportManagerRepository.AddAsync(transportManager);
        }

        public async Task<List<TransportManager>> GetAllTransportManagers()
        {
            return await _transportManagerRepository.GetAllAsync();
        }

        public async Task<TransportManager> GetTransportManager(int id)
        {
            return await _transportManagerRepository.GetByIdAsync(id);
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
