using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetAllByUser(int userId);
        Task<int> Insert(Orders orders);
    }
}