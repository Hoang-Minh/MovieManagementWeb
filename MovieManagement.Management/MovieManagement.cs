using System;
using System.Collections.Generic;
using System.Linq;
using MovieManagement.DataAccess;
using MovieManagement.DataContracts;

namespace MovieManagement.Management
{
    public class MovieManagement
    {
        private readonly MovieRepository _repo = new MovieRepository();
        public IList<MovieDTO> Search()
        {
            var result = _repo.SearchMovies();

            var toReturn = result.Select(x => new MovieDTO
            {
                Id = x.Id,
                AverageScore = (float)x.AverageScore,
                CategoryName = x.Category.Name,
                Length = x.Length,
                Rating = x.Rating,
                ReleaseDate = x.ReleaseDate,
                Title = x.Title
            }).ToList();

            return toReturn;
        }

        public MovieDTO GetMovie(Guid id)
        {
            var result = _repo.GetMovie(id);
            return new MovieDTO
            {
                Id = result.Id,
                AverageScore = (float)result.AverageScore,
                CategoryName = result.Category.Name,
                Length = result.Length,
                Rating = result.Rating,
                ReleaseDate = result.ReleaseDate,
                Title = result.Title
            };
        }

        public void DeleteMovie(Guid id)
        {
            _repo.DeleteMovie(id);
        }
        public void AddOrUpdateMovie(MovieDTO movie)
        {
            var movy = new Movy
            {
                Id = movie.Id != Guid.Empty ? movie.Id : Guid.NewGuid(),
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                AverageScore = movie.AverageScore,
                Length = movie.Length,
                Rating = movie.Rating
            };

            if (!string.IsNullOrEmpty(movie.CategoryName))
            {
                var categoryRepo = new CategoryRepository();
                var existingCateory = categoryRepo.GetCategoryByName(movie.CategoryName);
                if (existingCateory != null)
                {
                    movy.CategoryId = existingCateory.Id;
                }
            }

            if (movie.Id != Guid.Empty)
            {
                _repo.UpdateMovie(movy);
            }
            else
            {
                _repo.AddMovie(movy);
            }
        }

    }
}
