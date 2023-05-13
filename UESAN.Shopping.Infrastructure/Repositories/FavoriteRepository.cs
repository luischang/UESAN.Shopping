using Microsoft.EntityFrameworkCore;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;
using UESAN.Shopping.Infrastructure.Data;

namespace UESAN.Shopping.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbContext _dbContext;
        public FavoriteRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Favorite>> GetAll(int userId)
        {
            return await _dbContext
                            .Favorite
                            .Where(p => p.UserId == userId)
                            .Include(x => x.User)
                            .Include(z => z.Product)
                            .ThenInclude(q => q.Category)
                            .ToListAsync();
        }

        public async Task<bool> Insert(Favorite favorite)
        {
            await _dbContext.Favorite.AddAsync(favorite);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var favorite = await _dbContext.Favorite.FindAsync(id);
            if (favorite == null)
                return false;

            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }
    }
}
