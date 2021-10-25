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
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        // GET: api/<BusController>
        [HttpGet]
        public async Task<ActionResult<List<Bus>>> Get()
        {
            return await _busService.GetAllAsync();
        }

        // GET api/<BusController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> Get(int id)
        {
            return await _busService.GetBus(id);
        }

        // POST api/<BusController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Bus bus)
        {
            return await _busService.CreateBus(bus);
        }

        // PUT api/<BusController>/5
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
