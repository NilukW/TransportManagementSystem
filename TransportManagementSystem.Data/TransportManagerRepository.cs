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
    public class TransportManagerRepository : ITransportManagerRepository
    {
        private readonly IConfiguration configuration;
        public TransportManagerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(TransportManager entity)
        {
            var sql = "Insert into public.tranportmanager (fullname,dateofbirth,address,userid,licenseno,contactno) VALUES (@fullname,@dateofbirth,@address,@userid,@licenseno,@contactno)";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.tranportmanager WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<TransportManager>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.tranportmanager";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<TransportManager>(sql);
                return result.ToList();
            }
        }

        public async Task<TransportManager> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.tranportmanager WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<TransportManager>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(TransportManager entity)
        {
            throw new NotImplementedException();
        }
    }
}
