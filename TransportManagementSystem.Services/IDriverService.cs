using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IDriverService : IUserService
    {
        Task<Driver> CreateDriverProfile(Driver driver);
    }
}
