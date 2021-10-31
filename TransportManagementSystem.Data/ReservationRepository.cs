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
    public class ReservationRepository : IReservationRepository
    {
        private readonly IConfiguration configuration;
        public ReservationRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Reservation entity)
        {
            var sql = "Insert into public.reservation (passengerid,busrouteid,noofsheet,createdate,time) VALUES (@passengerid,@busrouteid,@noofsheet,@createdate,@time) RETURNING id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM public.reservation WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.reservation";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Reservation>(sql);
                return result.ToList();
            }
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.reservation WHERE Id = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Reservation>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
