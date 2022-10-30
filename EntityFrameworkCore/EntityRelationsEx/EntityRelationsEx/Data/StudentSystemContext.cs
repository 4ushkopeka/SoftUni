using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext:DbContext
    {
        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions<StudentSystemContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WIN-K3GD8E8BACN\\SQLEXPRESS;Database=SoftUni;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>(x =>
            {
                x.Property(e => e.Name).IsUnicode(true);
                x.Property(e => e.Description).IsUnicode(true);
                x.Property(e => e.StartDate).HasColumnType("smalldatetime");
                x.Property(e => e.EndDate).HasColumnType("smalldatetime");
                x.Property(e => e.Price).HasColumnType("decimal(15, 4)");
                x.HasMany(c => c.Resources).WithOne(c => c.Course);
                x.HasMany(c => c.HomeworkSubmissions).WithOne(c => c.Course);
            });
            builder.Entity<StudentCourse>(x =>
            {
                x.HasKey(e => new { e.StudentId, e.CourseId });

                x.Property(e => e.StudentId).HasColumnName("StudentID");

                x.Property(e => e.CourseId).HasColumnName("CourseID");

                x.HasOne(d => d.Student)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                x.HasOne(d => d.Course)
                    .WithMany(p => p.StudentsEnrolled)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<Resource>(x =>
            {
                x.Property(e => e.Name).IsUnicode(true);
                x.Property(c => c.Url).IsUnicode(false);
                x.HasOne(c => c.Course).WithMany(c => c.Resources);
            });
            builder.Entity<Student>(x =>
            {
                x.Property(e => e.Name).IsUnicode(true);
                x.Property(e => e.PhoneNumber).IsUnicode(false);
                x.Property(e => e.RegisteredOn).HasColumnType("smalldatetime");
                x.Property(e => e.Birthday).HasColumnType("smalldatetime");
                x.HasMany(e => e.HomeworkSubmissions).WithOne(e => e.Student);
            });
            builder.Entity<Homework>(x =>
            {
                x.Property(c => c.SubmissionTime).HasColumnType("smalldatetime");
                x.Property(c => c.Content).HasColumnName("[Content]");
                x.HasOne(c => c.Student).WithMany(c => c.HomeworkSubmissions);
                x.HasOne(c => c.Course).WithMany(c => c.HomeworkSubmissions);
            });
        }
    }
}
