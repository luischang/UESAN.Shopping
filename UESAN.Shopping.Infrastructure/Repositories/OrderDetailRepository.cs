using Microsoft.AspNetCore.Components.Web;
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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreDbContext _dbContext;

        public OrderDetailRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(IEnumerable<OrderDetail> orderDetails)
        {
            await _dbContext.OrderDetail.AddRangeAsync(orderDetails);
            var totalAmount = orderDetails.Sum(x => x.Quantity * x.Price);

            var order = await _dbContext
                        .Orders
                        .Where(x => x.Id == orderDetails.FirstOrDefault().OrdersId)
                        .FirstOrDefaultAsync();

            order.TotalAmount = totalAmount;
            _dbContext.Orders.Update(order);

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
