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
    public class PassengerRepository : IPassengerRepository
    {
        private readonly IConfiguration configuration;
        public PassengerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Passenger entity)
        {
            var sql = "Insert into public.passenger (fullname,dateofbirth,address,userid,licenseno,contactno) VALUES (@fullname,@dateofbirth,@address,@userid,@licenseno,@contactno) RETURNING id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.passenger WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Passenger>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.passenger";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Passenger>(sql);
                return result.ToList();
            }
        }

        public async Task<Passenger> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.passenger WHERE userid = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Passenger>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Passenger entity)
        {
            throw new NotImplementedException();
        }
    }
}
