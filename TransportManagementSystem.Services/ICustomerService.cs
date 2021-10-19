using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
    }
}