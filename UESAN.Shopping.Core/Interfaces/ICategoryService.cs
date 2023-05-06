using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryDescriptionDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<bool> Insert(CategoryInsertDTO categoryInsertDTO);
        Task<bool> Update(CategoryDescriptionDTO categoryDescriptionDTO);
    }
}