using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface ITransportManagerService : IUserService
    {
        Task<List<TransportManager>> GetAllTransportManagers();
        Task<TransportManager> GetTransportManager(int id);
        Task<int> CreateTransportManager(TransportManager driver);
    }
}
