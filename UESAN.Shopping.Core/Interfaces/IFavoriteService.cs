using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<FavoriteListDTO>> GetAll(int userId);
        Task<bool> Insert(FavoriteInsertDTO favoriteDTO);
    }
}