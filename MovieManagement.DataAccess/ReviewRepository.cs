using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieManagement.DataAccess
{
    public class CategoryRepository : BaseRepository
    {
        public IList<Category> SearchCategories()
        {
            return DbContext.Categories.ToList();
        }

        public Category GetCategory(Guid id)
        {
            var category = DbContext.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var lowerCaseName = name.ToLower();
            var category = DbContext.Categories.FirstOrDefault(x => x.Name.ToLower().Contains(lowerCaseName));
            return category;
        }

        public void AddCategory(Category category)
        {
            DbContext.Categories.Add(category);
            DbContext.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var category = GetCategory(id);
            if (category == null) return;
            DbContext.Categories.Remove(category);
            DbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var aCategory = GetCategory(category.Id);
            if (aCategory == null) return;
            aCategory.Name = category.Name;
            DbContext.SaveChanges();
        }
    }
}
