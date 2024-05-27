using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FiapHackaton.Domain.Implementations
{
	public class ScheduleRepository : IScheduleRepository
	{
		private readonly ApplicationDbContext _context;

		public ScheduleRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Schedule> GetScheduleById(int scheduleId)
		{
			return await _context.Schedules.FindAsync(scheduleId);
		}

		public async Task<List<Schedule>> GetAllSchedules()
		{
			return await _context.Schedules.ToListAsync();
		}

		public async Task AddSchedule(Schedule schedule)
		{
			_context.Schedules.Add(schedule);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateSchedule(Schedule schedule)
		{
			_context.Schedules.Update(schedule);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteSchedule(int scheduleId)
		{
			var schedule = await _context.Schedules.FindAsync(scheduleId);
			if (schedule != null)
			{
				//_context.Schedules.Remove(schedule);
				schedule.Deleted = true;
                _context.Schedules.Update(schedule);
                await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Schedule>> GetScheduleByUserId(int DoctorId)
		{
			return await _context.Schedules.Where(a=>a.DoctorID== DoctorId && !a.Deleted).ToListAsync();
		}
	}
}
