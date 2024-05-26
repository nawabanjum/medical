using FiapHackaton.Domain.Entities;

namespace FiapHackaton.Domain.Interfaces
{
	public interface IScheduleRepository
	{
		Task<Schedule> GetScheduleById(int scheduleId);
		Task<List<Schedule>> GetScheduleByUserId(int UserId);
		Task<List<Schedule>> GetAllSchedules();
		Task AddSchedule(Schedule schedule);
		Task UpdateSchedule(Schedule schedule);
		Task DeleteSchedule(int scheduleId);
	}
}
