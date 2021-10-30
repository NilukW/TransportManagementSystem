using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Data
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration configuration;
        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<Guid> AddAsync(Token entity)
        {
            var sql = "Insert into public.token (tokenId,userId,tokenType,createtime,expiredAt) VALUES (@tokenId,@userId,@tokenType,@createtime,@expiredAt) RETURNING tokenId";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<Guid>(sql,entity);
                return result;
            }
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM public.token WHERE tokenId = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Token>> GetAllAsync()
        {
            var sql = "SELECT id,tokenId,userId,createtime,expiredAt FROM public.token";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Token>(sql);
                return result.ToList();
            }
        }
        public async Task<Token> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM public.token WHERE tokenId = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Token>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<Token> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.token WHERE userid = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Token>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Token entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IGenericRepository<Token>.AddAsync(Token entity)
        {
            throw new NotImplementedException();
        }
    }
}
