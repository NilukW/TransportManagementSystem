using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface ITokenService
    {
        Task<List<Token>> GetAllTokens();
        Task<Token> GetToken(Guid tokenId);
        Task<Guid> CreateToken(Token token);
        Task<int> ManageTicket(Ticket token);
    }
}