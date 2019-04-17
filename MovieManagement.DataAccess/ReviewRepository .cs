using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MovieManagement.DataAccess
{
    public class ReviewRepository  : BaseRepository
    {
        public IList<Review> SearchReviews()
        {
            return DbContext.Reviews.ToList();
        }

        public Review GetReview(Guid id)
        {
            var review = DbContext.Reviews.FirstOrDefault(x => x.Id == id);
            return review;
        }

        public void AddReview(Review review)
        {
            DbContext.Reviews.Add(review);
            DbContext.SaveChanges();
        }

        public void DeleteReview(Guid id)
        {
            var review = GetReview(id);
            if (review == null) return;
            DbContext.Reviews.Remove(review);
            DbContext.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            var aMovie = GetReview(review.Id);
            if (aMovie == null) return;
            DbContext.Reviews.AddOrUpdate(review);
            DbContext.SaveChanges();
        }
    }
}
