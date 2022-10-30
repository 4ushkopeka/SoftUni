namespace Footballers.Data
{
    using Footballers.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamFootballer> TeamsFootballers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamFootballer>(x =>
            {
                x.HasKey(x => new { x.TeamId, x.FootballerId });

                x.HasOne(x => x.Footballer)
                .WithMany(x => x.TeamsFootballers)
                .HasForeignKey(x => x.FootballerId)
                .OnDelete(DeleteBehavior.Restrict);
                
                x.HasOne(x => x.Team)
                .WithMany(x => x.TeamsFootballers)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
