using System;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Data
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        Task<int> AddBusStop(BusStops entity);
    }
}