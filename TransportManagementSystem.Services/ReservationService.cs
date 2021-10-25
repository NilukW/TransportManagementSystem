using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;


namespace TransportManagementSystem.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<int> Reserve(Reservation reservation)
        {
            return await _reservationRepository.AddAsync(reservation);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<Reservation> GetReservation(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }
    }
}
