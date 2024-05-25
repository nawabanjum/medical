using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Interfaces;

namespace FiapHackaton.Application
{
	public class ScheduleService : IScheduleService
	{
		private readonly IScheduleRepository _scheduleRepository;

		public ScheduleService(IScheduleRepository scheduleRepository)
		{
			_scheduleRepository = scheduleRepository;
		}

		public async Task<Schedule> GetScheduleById(int scheduleId)
		{
			return await _scheduleRepository.GetScheduleById(scheduleId);
		}
		public async Task<List<Schedule>> GetScheduleByUserId(int UserId)
		{
			return await _scheduleRepository.GetScheduleByUserId(UserId);
		}
		public async Task<List<Schedule>> GetAllSchedules()
		{
			return await _scheduleRepository.GetAllSchedules();
		}

		public async Task AddSchedule(Schedule schedule)
		{
			await _scheduleRepository.AddSchedule(schedule);
		}

		public async Task UpdateSchedule(Schedule schedule)
		{
			await _scheduleRepository.UpdateSchedule(schedule);
		}

		public async Task DeleteSchedule(int scheduleId)
		{
			await _scheduleRepository.DeleteSchedule(scheduleId);
		}
	}
}
