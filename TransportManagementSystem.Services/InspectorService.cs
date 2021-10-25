using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class InspectorService : IInspectorService
    {
        public Task<int> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
