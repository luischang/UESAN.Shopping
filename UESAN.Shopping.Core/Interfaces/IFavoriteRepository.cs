using UESAN.Shopping.Core.Entities;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Favorite>> GetAll(int userId);
        Task<bool> Insert(Favorite favorite);
    }
}