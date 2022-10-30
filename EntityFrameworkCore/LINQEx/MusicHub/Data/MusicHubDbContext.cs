namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(x =>
            {
                x.HasKey(e => new { e.SongId, e.PerformerId });

                x.HasOne(e => e.Song)
                .WithMany(e => e.SongPerformers)
                .HasForeignKey(e => e.SongId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(e => e.Performer)
                .WithMany(e => e.PerformerSongs)
                .HasForeignKey(e => e.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Song>(x =>
            {
                x.HasMany(e => e.SongPerformers)
                .WithOne(e => e.Song)
                .HasForeignKey(e => e.SongId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Performer>(x =>
            {
                x.HasMany(e => e.PerformerSongs)
                .WithOne(e => e.Performer)
                .HasForeignKey(e => e.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Writer>(x =>
            {
                x.HasMany(e => e.Songs)
                .WithOne(e => e.Writer)
                .HasForeignKey(e => e.WriterId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Album>(x =>
            {
                x.HasMany(e => e.Songs)
                .WithOne(e => e.Album)
                .HasForeignKey(e => e.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Producer>(x =>
            {
                x.HasMany(e => e.Albums)
                .WithOne(e => e.Producer)
                .HasForeignKey(e => e.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
