using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TransportManagementSystem.Data;
using TransportManagementSystem.Model;


namespace TransportManagementSystem.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<int> CreateSchedule(Schedule schedule)
        {
            return await _scheduleRepository.AddAsync(schedule);
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            return await _scheduleRepository.GetAllAsync();
        }

        public async Task<Schedule> GetSchedule(int id)
        {
            return await _scheduleRepository.GetByIdAsync(id);
        }
    }
}
