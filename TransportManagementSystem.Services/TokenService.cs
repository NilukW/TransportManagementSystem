using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<List<Token>> GetAllTokens()
        {
            return await _tokenRepository.GetAllAsync();
        }

        public async Task<Token> GetToken(Guid tokenId)
        {
            return await _tokenRepository.GetByIdAsync(tokenId);
        }

        public async Task<Guid> CreateToken(Token token)
        {
            token.CreateTime = DateTime.Now;
            token.ExpiredAt = DateTime.Now.AddHours(21);
            return await _tokenRepository.AddAsync(token);
        }
    }
}
