using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Model;
using TransportManagementSystem.Services;

namespace TransportManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserProducer _userProducer;

        public UserController(UserProducer userProducer)
        {
            _userProducer = userProducer;
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> ProvisionDriver([FromBody] Driver driver)
        {
            IDriverService driverService = (IDriverService) _userProducer.getUser(Roles.driver);
            return await driverService.CreateDriverProfile(driver);
        }
    }
}
