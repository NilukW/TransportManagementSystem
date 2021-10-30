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
    public class TicketRepository : ITicketRepository
    {
        private readonly IConfiguration configuration;
        public TicketRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Ticket entity)
        {
            var sql = "Insert into public.ticket (busid,tokenid,busstopid,ischeckin,checkintime) VALUES (@busid,@tokenid,@busstopid,'1',@CheckedTime) RETURNING id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql,entity);
                return result;
            }
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            var sql = "SELECT * FROM public.ticket";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Ticket>(sql);
                return result.ToList();
            }
        }

        public async Task<int> GetTicketAsync(Ticket entity)
        {
            var sql = "SELECT id FROM public.ticket WHERE busid = @busid and tokenid = @tokenid";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<int>(sql, new { BusId = entity.BusId, TokenId = entity.TokenId });
                return result;
            }
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM public.ticket WHERE tokenId = @Id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Ticket>(sql, new { Id = id });
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Ticket entity)
        {
            var sql = "update public.ticket set ischeckout = '1',checkouttime= @CheckedTime where id = @id";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteScalarAsync<int>(sql, entity);
                return result;
            }
        }
    }
}
