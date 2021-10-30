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
    public class InspectorController : ControllerBase
    {
        private readonly UserProducer _userProducer;
        private readonly IInspectorService _inspectorService;

        public InspectorController(UserProducer userProducer)
        {
            _userProducer = userProducer;
            _inspectorService = (IInspectorService)_userProducer.GetUser(UserTypes.Inspector);
        }
        // GET: api/<InspectorController>
        [HttpGet]
       public async Task<ActionResult<List<Inspector>>> Get()
        {
            return await _inspectorService.GetAllInspectors();
        }

        // GET api/<InspectorController>/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Inspector>> Get(int id)
        {
            return await _inspectorService.GetInspector(id);
        }

        // POST api/<InspectorController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Inspector inspector)
        {
            return await _inspectorService.CreateInspector(inspector);
        }
    
    }
}
