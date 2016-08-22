using System.Collections.Generic;
using Day26_Repo.Models;

namespace Day26_Repo.Interfaces
{
    public interface IMovieService
    {
        void DeleteMovie(int id);
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void SaveMovie(Movie movie);
    }
}