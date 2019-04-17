using System;
using System.Collections.Generic;
using System.Web.Http;
using MovieManagement.DataContracts;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        private readonly Management.ReviewManagement _reviewManagement = new Management.ReviewManagement();

        [HttpGet]
        [Route("search")]
        public IList<ReviewDTO> Search()
        {
            return _reviewManagement.Search();
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id)
        {
            _reviewManagement.DeleteReview(id);
        }

        [HttpGet]
        [Route("{id}")]
        public ReviewDTO GetMovie(Guid id)
        {
            return _reviewManagement.GetReview(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateMovie(ReviewDTO review, Guid id)
        {
            _reviewManagement.AddOrUpdate(review);
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(ReviewDTO review, Guid id)
        {
            _reviewManagement.AddOrUpdate(review);
        }
    }
}
