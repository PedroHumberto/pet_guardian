using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetGuadian.Application.Interfaces;
using PetGuardian.Domain.Core.Data;
using PetGuardian.Domain.Models.Interfaces;
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

        public IUnityOfWork UnitOfWork => _context;


        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task InativateUser(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            user.Inativate();

            await _context.SaveChangesAsync();

            throw new NotImplementedException();
        }

        public void GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}