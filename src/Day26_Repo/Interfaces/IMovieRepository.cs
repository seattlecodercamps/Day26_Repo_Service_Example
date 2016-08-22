using System.Collections.Generic;
using Day26_Repo.Models;

namespace Day26_Repo.Interfaces
{
    public interface IMovieRepository
    {
        void DeleteMovie(int id);
        Movie GetMovieById(int id);
        List<Movie> GetMovies();
        void SaveMovie(Movie movie);
    }
}