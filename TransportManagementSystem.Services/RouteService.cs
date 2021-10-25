using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;


namespace TransportManagementSystem.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<int> CreateRoute([FromBody] Route route)
        {
            var routeId = await _routeRepository.AddAsync(route);
            foreach (var busStop in route.ListOfStops)
            {
                busStop.RouteId = routeId;
                await _routeRepository.AddBusStop(busStop);
            }
            return routeId;
        }

        public async Task<List<Route>> GetAllAsync()
        {
            return await _routeRepository.GetAllAsync();
        }

        public async Task<Route> GetRoute(int Id)
        {
            return await _routeRepository.GetByIdAsync(Id);
        }
    }
}
