using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<bool> Insert(IEnumerable<OrderDetail> orderDetails);
    }
}