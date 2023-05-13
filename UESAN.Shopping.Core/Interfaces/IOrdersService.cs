using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrdersDTO>> GetAllByUser(int userId);
        Task<int> Insert(OrdersInsertDTO ordersDTO);
    }
}