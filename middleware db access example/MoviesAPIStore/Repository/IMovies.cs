using MoviesAPIStore.Models;
using System.Collections.Generic;

namespace MoviesAPIStore.Repository
{
    public interface IMovies
    {
        List<MoviesTB> GetMoviesStore();
    }
}
