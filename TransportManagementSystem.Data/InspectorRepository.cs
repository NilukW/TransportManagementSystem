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
    public class InspectorRepository : IInspectorRepository
    {
        private readonly IConfiguration configuration;
        public InspectorRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Inspector entity)
        {
            var sql = "Insert into public.inspector (fullname,phone,location,userid) VALUES (@fullname,@phone,@location,@userid) RETURNING id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.inspector WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Inspector>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.inspector";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Inspector>(sql);
                return result.ToList();
            }
        }

        public async Task<Inspector> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.inspector WHERE userid = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Inspector>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Inspector entity)
        {
            throw new NotImplementedException();
        }
    }
}
