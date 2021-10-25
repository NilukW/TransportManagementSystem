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
        private readonly ITokenPaymentRepository _tokenPaymentRepository;
        public TokenService(ITokenRepository tokenRepository, ITokenPaymentRepository tokenPaymentRepository)
        {
            _tokenRepository = tokenRepository;
            _tokenPaymentRepository = tokenPaymentRepository;
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
            Guid tokenString = await _tokenRepository.AddAsync(token);
            var tokenOutput = await _tokenRepository.GetByIdAsync(tokenString);
            token.TokenPayment.TokenId = tokenOutput.Id;
            await _tokenPaymentRepository.AddAsync(token.TokenPayment);
            return tokenString;
        }
    }
}
