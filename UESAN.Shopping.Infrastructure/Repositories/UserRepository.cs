using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;
using UESAN.Shopping.Infrastructure.Data;

namespace UESAN.Shopping.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> SignIn(string email, string password)
        {
            return await _dbContext
                .User
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SignUp(User user)
        {
            await _dbContext.User.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return await _dbContext
                .User
                .Where(x => x.Email == email).AnyAsync();
        }
    }
}
