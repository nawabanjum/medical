using FiapHackaton.Domain.Entities;

namespace FiapHackaton.Application.Interfaces
{
	public interface IScheduleService
	{
		Task<Schedule> GetScheduleById(int scheduleId);
		Task<List<Schedule>> GetScheduleByUserId(int UserId);
		Task<List<Schedule>> GetAllSchedules();
		Task AddSchedule(Schedule schedule);
		Task UpdateSchedule(Schedule schedule);
		Task DeleteSchedule(int scheduleId);
	}
}
