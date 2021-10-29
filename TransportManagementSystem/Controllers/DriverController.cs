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
    public class DriverController : ControllerBase
    {
        private readonly UserProducer _userProducer;
        private readonly IDriverService _driverService;

        public DriverController(UserProducer userProducer)
        {
            _userProducer = userProducer;
            _driverService = (IDriverService)_userProducer.GetUser(UserTypes.Driver);
        }
        // GET: api/<DriverController>
        [HttpGet]
       public async Task<ActionResult<List<Driver>>> Get()
        {
            return await _driverService.GetAllDrivers();
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> Get(int id)
        {
            return await _driverService.GetDriver(id);
        }

        // POST api/<DriverController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Driver driver)
        {
            return await _driverService.CreateDriver(driver);
        }
    
    }
}
