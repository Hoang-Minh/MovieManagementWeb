using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MovieManagement.DataAccess
{
    public class MovieRepository : BaseRepository
    {
        public IList<Movy> SearchMovies()
        {
            return DbContext.Movies.ToList();
        }

        public Movy GetMovie(Guid id)
        {
            var movie = DbContext.Movies.FirstOrDefault(x => x.Id == id);
            return movie;
        }

        public void AddMovie(Movy movie)
        {
            DbContext.Movies.Add(movie);
            DbContext.SaveChanges();
        }

        public void DeleteMovie(Guid id)
        {
            var movie = GetMovie(id);
            if (movie == null) return;
            DbContext.Movies.Remove(movie);
            DbContext.SaveChanges();
        }

        public void UpdateMovie(Movy movie)
        {
            var aMovie = GetMovie(movie.Id);
            if (aMovie == null) return;
            DbContext.Movies.AddOrUpdate(movie);
            DbContext.SaveChanges();
        }
    }
}
