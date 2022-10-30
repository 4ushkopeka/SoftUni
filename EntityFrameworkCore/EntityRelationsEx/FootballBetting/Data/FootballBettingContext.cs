using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext:DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions<FootballBettingContext> op):base(op)
        {

        }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WIN-K3GD8E8BACN\\SQLEXPRESS;Database=SoftUni;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PlayerStatistic>(x =>
            {
                x.HasKey(e => new { e.PlayerId, e.GameId });
                x.HasOne(e => e.Player).WithMany(e => e.PlayerStatistics).HasForeignKey(e => e.PlayerId).OnDelete(DeleteBehavior.Restrict);
                x.HasOne(e => e.Game).WithMany(e => e.PlayerStatistics).HasForeignKey(e => e.GameId).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Team>(x =>
            {
                x.HasOne(e => e.PrimaryKitColor).WithMany(e => e.PrimaryKitTeams).HasForeignKey(e => e.PrimaryKitColorId).OnDelete(DeleteBehavior.Restrict);
                x.HasOne(e => e.SecondaryKitColor).WithMany(e => e.SecondaryKitTeams).HasForeignKey(e => e.SecondaryKitColorId).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Game>(x =>
            {
                x.HasOne(e => e.HomeTeam).WithMany(e => e.HomeGames).HasForeignKey(e => e.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
                x.HasOne(e => e.AwayTeam).WithMany(e => e.AwayGames).HasForeignKey(e => e.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
