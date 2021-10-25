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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        // GET: api/<ScheduleController>
        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> Get()
        {
            return await _scheduleService.GetAllAsync();
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> Get(int id)
        {
            return await _scheduleService.GetSchedule(id);
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Schedule schedule)
        {
            return await _scheduleService.CreateSchedule(schedule);
        }

        // PUT api/<ScheduleController>/5
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
