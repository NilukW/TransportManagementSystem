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
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        // GET: api/<RouteController>
        [HttpGet]
        public async Task<ActionResult<List<Route>>> Get()
        {
            return await _routeService.GetAllAsync();
        }

        // GET api/<RouteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> Get(int id)
        {
            return await _routeService.GetRoute(id);
        }

        // POST api/<RouteController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Route route)
        {
            return await _routeService.CreateRoute(route);
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
