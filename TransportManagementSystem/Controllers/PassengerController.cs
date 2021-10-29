using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Model;
using TransportManagementSystem.Services;
using static TransportManagementSystem.Model.Types.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransportManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly UserProducer _userProducer;
        private readonly IPassengerService _passengerService;

        public PassengerController(UserProducer userProducer)
        {
            _userProducer = userProducer;
            _passengerService = (IPassengerService)_userProducer.GetUser(UserTypes.Driver);
        }

        // GET: api/<PassengerController>
        [HttpGet]
        public async Task<ActionResult<List<Passenger>>> Get()
        {
            return await _passengerService.GetAllPassengers();
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> Get(int id)
        {
            return await _passengerService.GetPassenger(id);
        }

        // POST api/<PassengerController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Passenger passenger)
        {
            return await _passengerService.AddPassenger(passenger);
        }
    }
}
