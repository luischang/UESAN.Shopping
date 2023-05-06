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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDescriptionDTO>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var categoriesDTO = new List<CategoryDescriptionDTO>();
            
            foreach (var category in categories)
            {
                var categoryDTO = new CategoryDescriptionDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;                

                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;
        }
        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _categoryRepository.GetById(id);
            var categoryDTO = new CategoryDTO();
            categoryDTO.Id = category.Id;
            categoryDTO.Description = category.Description;
            categoryDTO.IsActive = category.IsActive;
            return categoryDTO;
        }

        public async Task<bool> Insert(CategoryInsertDTO categoryInsertDTO)
        {
            var category = new Category();
            category.Description = categoryInsertDTO.Description;
            category.IsActive = categoryInsertDTO.IsActive;

            var result = await _categoryRepository.Insert(category);
            return result;
        }

        public async Task<bool> Update(CategoryDescriptionDTO categoryDescriptionDTO)
        {
            var category = await _categoryRepository.GetById(categoryDescriptionDTO.Id);
            if (category == null)
                return false;
            category.Description = categoryDescriptionDTO.Description;

            var result = await _categoryRepository.Update(category);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
                return false;

            var result = await _categoryRepository.Delete(id);
            return result;
        }


    }
}
