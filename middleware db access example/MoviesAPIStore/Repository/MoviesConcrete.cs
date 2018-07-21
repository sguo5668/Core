using MoviesAPIStore.Models;
using MoviesAPIStore.MoviesContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPIStore.Repository
{
    public class MoviesConcrete : IMovies
    {
        private DatabaseContext _context;
        public MoviesConcrete(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LatestMovies
        public List<MoviesTB> GetMoviesStore()
        {
            try
            {
                var listofMovies = _context.MoviesTB.ToList();
                return listofMovies;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
