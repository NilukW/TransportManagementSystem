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
using TransportManagementSystem.Model.Auth;

namespace TransportManagementSystem.Data
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConfiguration configuration;
        public AuthenticationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<User> ValidateUser(string userName, string password)
        {
            var sql = "SELECT * FROM public.user WHERE username = @username and password = @password ";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = userName , Password = password});
                return result;
            }
        }
        public Task<int> AddAsync(AuthenticateData entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuthenticateData>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticateData> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(AuthenticateData entity)
        {
            throw new NotImplementedException();
        }

    }
}
