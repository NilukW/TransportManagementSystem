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
    public class BusRepository : IBusRepository
    {
        private readonly IConfiguration configuration;
        public BusRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Bus entity)
        {
            var sql = "Insert into public.bus (buscode,numberplate,companyname,manufacturer,mnufactureryear,numberofseats,qrcode) VALUES (@buscode,@numberplate,@companyname,@manufacturer,@numberofseats,@numberofseats,@qrcode)";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.bus WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.bus";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Bus>(sql);
                return result.ToList();
            }
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.bus WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Bus>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
