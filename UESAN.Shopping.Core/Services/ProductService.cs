using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetAll()
        {
            var products = await _repository.GetAll();

            var productsDTO = products.Select(p => new ProductCategoryDTO
            {
                Id = p.Id,
                Description = p.Description,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock = p.Stock,
                Category = new CategoryDescriptionDTO()
                {
                    Id = p.Category.Id,
                    Description = p.Category.Description
                }
            });
            return productsDTO;
        }

        public async Task<ProductCategoryDTO> GetById(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
                return null;
            var productDTO = new ProductCategoryDTO()
            {
                Id = product.Id,
                Description = product.Description,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.Stock,
                Category = new CategoryDescriptionDTO() { Id = product.Category.Id, Description = product.Category.Description }
            };
            return productDTO;
        }

        public async Task<bool> Insert(ProductInsertDTO productDTO)
        {
            var product = new Product()
            {
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                Price = productDTO.Price,
                Stock = productDTO.Stock,
                IsActive = true,
                CategoryId = productDTO.CategoryId
            };
            return await _repository.Insert(product);
        }

        public async Task<bool> Update(ProductDTO productDTO)
        {
            var product = new Product()
            {
                Id = productDTO.Id,
                Description = productDTO.Description,
                ImageUrl = productDTO.ImageUrl,
                Price = productDTO.Price,
                Stock = productDTO.Stock,
                IsActive = true,
                CategoryId = productDTO.CategoryId
            };
            return await _repository.Update(product);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }


    }
}
