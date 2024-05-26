using FiapHackaton.Application.Interfaces;
using FiapHackaton.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapHackaton.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            var schedule = await _scheduleService.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSchedulesByUserId(int userId)
        {
            var schedules = await _scheduleService.GetScheduleByUserId(userId);
            return Ok(schedules);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedules();
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule(Schedule schedule)
        {
            await _scheduleService.AddSchedule(schedule);
            return CreatedAtAction(nameof(GetScheduleById), new { id = schedule.ScheduleID }, schedule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchedule(Schedule schedule)
        {
            if ( schedule.ScheduleID<=0)
            {
                return BadRequest();
            }

            await _scheduleService.UpdateSchedule(schedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            await _scheduleService.DeleteSchedule(id);
            return NoContent();
        }
    }
}
