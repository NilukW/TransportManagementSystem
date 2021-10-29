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
    public class TransportManagerController : ControllerBase
    {
        private readonly UserProducer _userProducer;
        private readonly ITransportManagerService _transportManagerService;

        public TransportManagerController(UserProducer userProducer)
        {
            _userProducer = userProducer;
            _transportManagerService = (ITransportManagerService)_userProducer.GetUser(UserTypes.TransportManager);
        }
        // GET: api/<TransportManagerController>
        [HttpGet]
       public async Task<ActionResult<List<TransportManager>>> Get()
        {
            return await _transportManagerService.GetAllTransportManagers();
        }

        // GET api/<TransportManagerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportManager>> Get(int id)
        {
            return await _transportManagerService.GetTransportManager(id);
        }

        // POST api/<TransportManagerController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TransportManager transportManager)
        {
            return await _transportManagerService.CreateTransportManager(transportManager);
        }
    
    }
}
