using Microsoft.EntityFrameworkCore;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;
using Watchlist.Services.Contracts;

namespace Watchlist.Views.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }
        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            Movie movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };
            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (movie == null)
            {
                throw new ArgumentException("Invalid movie Id!");
            }
            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }
            if (!user.UsersMovies.Any(x => x.MovieId == movie.Id))
            {
                UserMovie mov = new UserMovie
                {
                    UserId = user.Id,
                    MovieId = movie.Id,
                };
                await context.UsersMovies.AddAsync(mov);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllAsync()
        {
            var movies = await context.Movies.Include(x => x.Genre).ToListAsync();

            return movies.Select(x => new MovieViewModel
            {
                Title = x.Title,
                Genre = x.Genre?.Name,
                Rating = x.Rating,
                Id = x.Id,
                Director = x.Director,
                ImageUrl = x.ImageUrl
            });
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }
            return user.UsersMovies.Select(x => new MovieViewModel
            {
                Title = x.Movie.Title,
                Rating = x.Movie.Rating,
                Genre = x.Movie.Genre?.Name,
                Director = x.Movie.Director,
                ImageUrl = x.Movie.ImageUrl
            }).ToList();
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == movieId);
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (movie == null)
            {
                throw new ArgumentException("Invalid movie Id!");
            }
            if (user == null)
            {
                throw new ArgumentException("Invalid user Id!");
            }
            var del = user.UsersMovies.FirstOrDefault(x => x.UserId == user.Id && x.MovieId == movie.Id);
            if (del != null)
            {
                user.UsersMovies.Remove(del);
                await context.SaveChangesAsync();
            }
        }
    }
}
