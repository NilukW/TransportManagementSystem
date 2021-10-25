using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Data
{
    public class TokenPaymentRepository : ITokenPaymentRepository
    {
        private readonly IConfiguration configuration;
        public TokenPaymentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(TokenPayments entity)
        {
            var sql = "Insert into public.tokenpayments (tokenid,cardnumber,nameoncard,amount,cvv,expirydate) VALUES (@tokenid,@cardnumber,@nameoncard,@amount,@cvv,@expirydate)";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TokenPayments>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TokenPayments> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.tokenpayments WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<TokenPayments>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(TokenPayments entity)
        {
            throw new NotImplementedException();
        }
    }
}
