using System.Collections.Generic;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface ICustomerService
    {
        System.Threading.Tasks.Task<List<Customer>> GetAllAsync();
    }
}