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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IConfiguration configuration;
        public ScheduleRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Schedule entity)
        {
            var sql = "Insert into public.schedule (routeid,starttime,endtime,driverid,status) VALUES (@routeid,@starttime,@endtime,@driverid,'1')";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.Route WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.schedule";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Schedule>(sql);
                return result.ToList();
            }
        }

        public async Task<Schedule> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.schedule WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Schedule>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Schedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
