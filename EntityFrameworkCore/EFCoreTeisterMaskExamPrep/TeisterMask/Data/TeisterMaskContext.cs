namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>(x =>
            {
                x.HasKey(e => new { e.EmployeeId, e.TaskId });

                x.HasOne(e => e.Employee)
                .WithMany(e => e.EmployeesTasks)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(e => e.Task)
                .WithMany(e => e.EmployeesTasks)
                .HasForeignKey(e => e.TaskId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}