using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetReservation(int id);
        Task<int> Reserve(Reservation reservation);
    }
}