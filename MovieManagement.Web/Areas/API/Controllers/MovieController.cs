using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieManagement.DataContracts;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private readonly Management.MovieManagement _movieManagement = new Management.MovieManagement();

        [HttpGet]
        [Route("search")]
        public IList<MovieDTO> Search()
        {
            return _movieManagement.Search();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _movieManagement.DeleteMovie(id);
        }

        [HttpGet]
        [Route("{id}")]
        public MovieDTO GetMovie(Guid id)
        {
            return _movieManagement.GetMovie(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateMovie(MovieDTO movie, Guid id)
        {
            _movieManagement.AddOrUpdateMovie(movie);
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(MovieDTO movie, Guid id)
        {
            _movieManagement.AddOrUpdateMovie(movie);
        }
    }
}
