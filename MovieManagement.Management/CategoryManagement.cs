using MovieManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieManagement.DataContracts;

namespace MovieManagement.Management
{
    public class CategoryManagement
    {
        private readonly CategoryRepository _repo = new CategoryRepository();

        public IList<CategoryDTO> Search()
        {
            var result = _repo.SearchCategories();
            var toResult = result.Select(x => new CategoryDTO
            {
                Id = new Guid(),
                Name = x.Name
            }).ToList();

            return toResult;
        }

        public CategoryDTO GetCategory(Guid id)
        {
            var result = _repo.GetCategory(id);

            return new CategoryDTO
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public void DeleteCategory(Guid id)
        {
            _repo.DeleteCategory(id);
        }

        public void AddOrUpdate(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id != Guid.Empty ? categoryDTO.Id : Guid.NewGuid(),
                Name = categoryDTO.Name,
            };

            if (categoryDTO.Id != Guid.Empty)
            {
                _repo.UpdateCategory(category);
            }
            else
            {
                _repo.AddCategory(category);
            }
        }
    }
}
