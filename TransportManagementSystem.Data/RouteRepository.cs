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
    public class RouteRepository : IRouteRepository
    {
        private readonly IConfiguration configuration;
        public RouteRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Route entity)
        {
            var sql = "Insert into public.Route (isactive) VALUES ('1')";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> AddBusStop(BusStops entity)
        {
            var sql = "Insert into public.Route (name,latitude,longitude,routeid) VALUES (@name,@latitude,@longitude,@routeid)";
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

        public async Task<List<Route>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.Route";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Route>(sql);
                return result.ToList();
            }
        }

        public async Task<Route> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.Route WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Route>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Route entity)
        {
            throw new NotImplementedException();
        }
    }
}
