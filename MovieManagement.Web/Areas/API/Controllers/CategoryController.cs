using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieManagement.DataContracts;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        private readonly Management.CategoryManagement _categoryManagement = new Management.CategoryManagement();

        [HttpGet]
        [Route("search")]
        public IList<CategoryDTO> Search()
        {
            return _categoryManagement.Search();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _categoryManagement.DeleteCategory(id);
        }

        [HttpGet]
        [Route("{id}")]
        public CategoryDTO GetCategory(Guid id)
        {
            return _categoryManagement.GetCategory(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateMovie(CategoryDTO category, Guid id)
        {
            _categoryManagement.AddOrUpdate(category);
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(CategoryDTO category, Guid id)
        {
            _categoryManagement.AddOrUpdate(category);
        }
    }
}
