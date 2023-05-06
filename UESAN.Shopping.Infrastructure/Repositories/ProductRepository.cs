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
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext
                .Product
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> Insert(Product product)
        {
            await _dbContext.Product.AddAsync(product);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Product product)
        {
            _dbContext.Product.Update(product);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var product = await _dbContext
                .Product
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            product.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
