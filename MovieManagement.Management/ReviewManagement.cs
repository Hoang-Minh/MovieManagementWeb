using MovieManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieManagement.DataContracts;

namespace MovieManagement.Management
{
    public class ReviewManagement
    {
        private readonly ReviewRepository _repo = new ReviewRepository();

        public IList<ReviewDTO> Search()
        {
            var result = _repo.SearchReviews();

            var toResult = result.Select(x => new ReviewDTO()
            {
                Id = new Guid(),
                Score = x.Score
            }).ToList();

            return toResult;
        }

        public ReviewDTO GetReview(Guid id)
        {
            var result = _repo.GetReview(id);

            return new ReviewDTO
            {
                Id = result.Id,
                Score = result.Score
            };
        }

        public void DeleteReview(Guid id)
        {
            _repo.DeleteReview(id);
        }

        public void AddOrUpdate(ReviewDTO reviewDTO)
        {
            var review = new Review
            {
                Id = reviewDTO.Id != Guid.Empty ? reviewDTO.Id : Guid.NewGuid(),
                Score = reviewDTO.Score,
            };

            if (reviewDTO.Id != Guid.Empty)
            {
                _repo.UpdateReview(review);
            }
            else
            {
                _repo.AddReview(review);
            }
        }
    }
}
