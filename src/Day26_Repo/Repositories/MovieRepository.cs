using Day26_Repo.Data;
using Day26_Repo.Interfaces;
using Day26_Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day26_Repo.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Movie> GetMovies()
        {
            return _db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.Where(m => m.Id == id).FirstOrDefault();
            //return _db.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void SaveMovie(Movie movie)
        {
            if(movie.Id == 0)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
            }
            else
            {
                var movieToEdit = _db.Movies.Where(m => m.Id == movie.Id).FirstOrDefault();
                movieToEdit.Name = movie.Name;
                movieToEdit.Director = movie.Director;
                _db.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = _db.Movies.Where(m => m.Id == id).FirstOrDefault();
            _db.Movies.Remove(movieToDelete);
            _db.SaveChanges();
        }

    }
}
