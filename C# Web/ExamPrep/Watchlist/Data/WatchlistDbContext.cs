using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Watchlist.Data.Models;

namespace Watchlist.Data
{
    public class WatchlistDbContext : IdentityDbContext<User>
    {
        public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UsersMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserMovie>(x => x.HasKey(e => new { e.UserId, e.MovieId }));

            builder.Entity<UserMovie>(x =>
            x.HasOne(x => x.User)
            .WithMany(x => x.UsersMovies)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict));

            builder.Entity<UserMovie>(x =>
            x.HasOne(x => x.Movie)
            .WithMany(x => x.UsersMovies)
            .HasForeignKey(x => x.MovieId)
            .OnDelete(DeleteBehavior.Restrict));
             builder
                 .Entity<Genre>()
                 .HasData(new Genre()
                 {
                     Id = 1,
                     Name = "Action"
                 },
                 new Genre()
                 {
                     Id = 2,
                     Name = "Comedy"
                 },
                 new Genre()
                 {
                     Id = 3,
                     Name = "Drama"
                 },
                 new Genre()
                 {
                     Id = 4,
                     Name = "Horror"
                 },
                 new Genre()
                 {
                     Id = 5,
                     Name = "Romantic"
                 });
            
            base.OnModelCreating(builder);
        }
    }
}