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
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrdersRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Insert(Orders orders)
        {
            await _dbContext.Orders.AddAsync(orders);
            await _dbContext.SaveChangesAsync();
            return orders.Id;
        }

        public async Task<IEnumerable<Orders>> GetAllByUser(int userId)
        {
            return await _dbContext
                .Orders
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
