using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IDriverService : IUserService
    {
        Task<List<Driver>> GetAllDrivers();
        Task<Driver> GetDriver(int id);
        Task<int> CreateDriver(Driver driver);
    }
}
