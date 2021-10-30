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
    public class DriverRepository : IDriverRepository
    {
        private readonly IConfiguration configuration;
        public DriverRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Driver entity)
        {
            var sql = "Insert into public.driver (fullname,dateofbirth,address,userid,licenseno,contactno) VALUES (@fullname,@dateofbirth,@address,@userid,@licenseno,@contactno) RETURNING id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.driver WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Driver>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.driver";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Driver>(sql);
                return result.ToList();
            }
        }

        public async Task<Driver> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.driver WHERE userid = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Driver>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Driver entity)
        {
            throw new NotImplementedException();
        }
    }
}
