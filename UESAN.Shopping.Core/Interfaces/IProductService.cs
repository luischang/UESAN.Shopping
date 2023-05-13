using UESAN.Shopping.Core.DTOs;

namespace UESAN.Shopping.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAll();
        Task<ProductCategoryDTO> GetById(int id);
        Task<bool> Insert(ProductInsertDTO productDTO);
        Task<bool> Update(ProductDTO productDTO);
        Task<bool> Delete(int id);

    }
}