using Microsoft.EntityFrameworkCore;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Repositories;
using PetGuardian.Models.Models;

namespace PetGuadian.API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContextDb _context;

        public UserRepository(AppContextDb context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.Commit();
        }

        public async Task InativateUser(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            user.Inativate();

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public void UpdateUser(User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}