using FiapHackaton.Domain.Entities;
using FiapHackaton.Domain.Interfaces;
using FiapHackaton.Infrastructure.Data.Context;
using FiapHackaton.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FiapHackaton.Domain.Implementations
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }

        public async Task AddAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
                await _context.SaveChangesAsync();
            }
        }

		public async Task<UserProfile> LoginAsync(LoginModel model)
		{
			return await _context.UserProfiles.FirstOrDefaultAsync(a => a.Email == model.Email && a.Password == model.Password);

		}

        public async Task<IEnumerable<UserProfile>> GetAllDoctorsAsync()
        {

            return await _context.UserProfiles.Where(a=>a.UserTypeId==1).ToListAsync();
        }

        public async Task<IEnumerable<UserProfile>> GetAllPatientsAsync()
        {
            return await _context.UserProfiles.Where(a => a.UserTypeId == 2).ToListAsync();
        }
       

        public async Task<UserProfile> GetByEmail(string email)
        {
            return await _context.UserProfiles.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }
    }
}
