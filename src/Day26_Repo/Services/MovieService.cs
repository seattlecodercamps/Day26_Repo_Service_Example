using Day26_Repo.Interfaces;
using Day26_Repo.Models;
using Day26_Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day26_Repo.Services
{
    public class MovieService : IMovieService
    {
        private IGenericRepository _repo;
        public MovieService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _repo.Query<Movie>().ToList();
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            var movie = _repo.Query<Movie>().Where(m => m.Id == id).FirstOrDefault();
            return movie;
        }

        public void SaveMovie(Movie movie)
        {
            if(movie.Id == 0)
            {
                _repo.Add(movie);
            }
            else
            {
                _repo.Update(movie);
            }
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = this.GetMovieById(id);
            _repo.Delete(movieToDelete);
        }
    }
}
