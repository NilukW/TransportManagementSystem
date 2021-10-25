using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Model;
using TransportManagementSystem.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        // GET: api/<RouteController>
        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> Get()
        {
            return await _reservationService.GetAllAsync();
        }

        // GET api/<RouteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> Get(int id)
        {
            return await _reservationService.GetReservation(id);
        }

        // POST api/<RouteController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Reservation reservation)
        {
            return await _reservationService.Reserve(reservation);
        }

        // PUT api/<RouteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
