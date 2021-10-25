using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IBusService
    {
        Task<List<Bus>> GetAllAsync();
        Task<Bus> GetBus(int Id);
        Task<int> CreateBus(Bus bus);
    }
}