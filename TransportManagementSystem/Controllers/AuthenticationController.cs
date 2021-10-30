using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Model;
using TransportManagementSystem.Model.Auth;
using TransportManagementSystem.Services;

namespace TransportManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost]
        public async Task<ActionResult<User>> Auth([FromBody] AuthenticateData authenticateData)
        {
            var user = await _authenticationService.ValidateUser(authenticateData.Username, authenticateData.Password);
            if (user != null)
            {
                return user;
            }
            else
            {
                return  StatusCode(StatusCodes.Status401Unauthorized,"Authentication failed! Try again.");
            }
        }
    }
}
