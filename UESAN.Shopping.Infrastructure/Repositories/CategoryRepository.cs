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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext
                         .Category
                         .Where(x => x.IsActive == true)
                         .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext
                        .Category
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findCategory = await _dbContext
                                .Category
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
            if (findCategory == null)
                return false;

            findCategory.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
