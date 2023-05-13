using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrdersService(IOrdersRepository ordersRepository
                    , IOrderDetailRepository orderDetailRepository)
        {
            _ordersRepository = ordersRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId)
        {
            var orders = await _ordersRepository.GetAllByUser(userId);
            if (!orders.Any())
                return null;

            var ordersDTO = new List<OrdersDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new OrdersDTO()
                {
                    Id = order.Id,
                    Status = order.Status,
                    TotalAmount = order.TotalAmount
                };
                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }

        public async Task<int> Insert(OrdersInsertDTO ordersDTO)
        {
            var orders = new Orders()
            {
                UserId = ordersDTO.UserId,
                CreatedAt = DateTime.Now,
                Status = "A",
                TotalAmount = 0
            };

            var resultOrderId = await _ordersRepository
                                .Insert(orders);

            var orderDetailList = new List<OrderDetail>();
            foreach (var item in ordersDTO.OrderDetail)
            {
                var orderDetail = new OrderDetail()
                {
                    OrdersId = resultOrderId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    CreatedAt = DateTime.Now,
                    ProductId = item.ProductId,
                };
                orderDetailList.Add(orderDetail);
            }

            await _orderDetailRepository.Insert(orderDetailList);
            //TODO: Trabajar con transacciones
            return resultOrderId;
        }
    }
}
