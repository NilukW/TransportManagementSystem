using System;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Data
{
    public interface ITokenRepository : IGenericRepository<Token>
    {
        Task<int> DeleteAsync(Guid id);
        Task<Token> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Token entity);
    }
}