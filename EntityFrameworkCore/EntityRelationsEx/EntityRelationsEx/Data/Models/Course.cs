using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            StudentsEnrolled = new HashSet<StudentCourse>();
            HomeworkSubmissions = new HashSet<Homework>();
            Resources = new HashSet<Resource>();
        }
        [Key]
        public int CourseId { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
