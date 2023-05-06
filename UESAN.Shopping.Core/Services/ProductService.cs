using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.Core.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _repository.GetAll();
            var productsDTO = products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Description = p.Description,
                Discount = p.Discount,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                Stock   = p.Stock,
                CategoryId = p.CategoryId,
            });
            return productsDTO;
        }

        public async Task<ProductDTO> GetById(int id)
        { 
            var product = await _repository.GetById(id);
            if (product == null)
                return null;

            var productDTO = new ProductDTO()
            {
                Id = product.Id,
                Description = product.Description,
                Discount = product.Discount,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
            return productDTO;
        }




    }
}
