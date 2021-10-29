using System;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Data
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<int> GetTicketAsync(Ticket entity);
    }
}