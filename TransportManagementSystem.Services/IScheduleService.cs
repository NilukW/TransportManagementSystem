using System.Collections.Generic;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetAllAsync();
        Task<Schedule> GetSchedule(int id);
        Task<int> CreateSchedule(Schedule schedule);
    }
}