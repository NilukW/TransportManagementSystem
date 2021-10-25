using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;


namespace TransportManagementSystem.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;
        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<int> CreateBus([FromBody] Bus bus)
        {
            return await _busRepository.AddAsync(bus);
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            return await _busRepository.GetAllAsync();
        }

        public async Task<Bus> GetBus(int Id)
        {
            return await _busRepository.GetByIdAsync(Id);
        }
    }
}
