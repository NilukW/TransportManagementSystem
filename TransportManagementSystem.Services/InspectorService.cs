using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class InspectorService : IInspectorService
    {
        private readonly IInspectorRepository _inspectorRepository;
        private readonly IUserRepository _userRepository;

        public InspectorService(IUserRepository userRepository, IInspectorRepository inspectorRepository)
        {
            _inspectorRepository = inspectorRepository;
            _userRepository = userRepository;
        }
        public async Task<int> CreateInspector(Inspector inspector)
        {
            inspector.UserId = await _userRepository.AddAsync(inspector as User);
            await _inspectorRepository.AddAsync(inspector);
            return inspector.UserId;
        }

        public Task<int> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Inspector>> GetAllInspectors()
        {
            return await _inspectorRepository.GetAllAsync();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Inspector> GetInspector(int id)
        {
            return await _inspectorRepository.GetByIdAsync(id);
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
