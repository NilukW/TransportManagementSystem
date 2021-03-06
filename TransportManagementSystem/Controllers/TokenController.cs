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
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Token>>> GetAllTokens()
        {
            return await _tokenService.GetAllTokens();
        }

        [HttpGet("{tokenId}")]
        public async Task<ActionResult<Token>> GetToken(Guid tokenId)
        {
            return await _tokenService.GetToken(tokenId);
        }

        [HttpGet]
        [Route("/api/GetTokenByUser/{userId}")]
        public async Task<ActionResult<Token>> GetTokenByUser(int userId)
        {
            return await _tokenService.GetToken(userId);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateToken([FromBody] Token token)
        {
            return await _tokenService.CreateToken(token);
        }

        [HttpPost]
        [Route("/api/Ticket")]
        public async Task<ActionResult<int>> CreateTicket([FromBody] Ticket ticket)
        {
            return await _tokenService.ManageTicket(ticket);
        }
    }
}
