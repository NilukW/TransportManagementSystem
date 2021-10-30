using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IInspectorService : IUserService
    {
        Task<List<Inspector>> GetAllInspectors();
        Task<Inspector> GetInspector(int id);
        Task<int> CreateInspector(Inspector inspector);
    }
}
