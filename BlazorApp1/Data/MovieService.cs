//using BlazorApp1.Data.BlazorApp1Context;
using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class MovieService
    {
        private readonly BlazorApp1Context _context;
        public MovieService(BlazorApp1Context context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }

        //public async Task<List<Movie>> GetForecastAsync(string strCurrentUser)
        public async Task<List<Movie>> GetMovieAsync()
        {
            // Get Weather Forecasts  
            //_context.Movie.Add(Movie);
            //await _context.SaveChangesAsync();

            return await _context.Movie

                 // Only get entries for the current logged in user
                 //.Where(x => x.UserName == strCurrentUser)

                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking()
                 .ToListAsync();

        }
        public Task<Movie> CreateMovieAsync(Movie movie)
        {
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return Task.FromResult(movie);
        }
        public Task<bool>UpdateMovieAsync(Movie objMovie)
        {
            var ExistingMovie =
                _context.Movie
                .Where(x => x.Id == objMovie.Id)
                .FirstOrDefault();

            if (ExistingMovie != null)
            {
                ExistingMovie.ReleaseDate =
                    objMovie.ReleaseDate;
                ExistingMovie.Price =
                    objMovie.Price;
                ExistingMovie.Title =
                    objMovie.Title;
                ExistingMovie.Genre =
                    objMovie.Genre;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<bool>

        DeleteMovieAsync(Movie objMovie)
        {
            //can replace this with _context.Movie.Remove(objMovie)?
            /*
            var ExistingMovie =
                _context.Movie
                .Where(x => x.Id == objMovie.Id)
                .FirstOrDefault();
            
            if (ExistingMovie != null)
            {
                _context.Movie.Remove(ExistingMovie);
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
            */
            _context.Movie.Remove(objMovie);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }

}
