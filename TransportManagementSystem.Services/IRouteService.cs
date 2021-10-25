using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IRouteService
    {
        Task<List<Route>> GetAllAsync();
        Task<Route> GetRoute(int id);
        Task<int> CreateRoute(Route route);
    }
}