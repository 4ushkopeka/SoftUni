using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        public string Content { get; set; }
        public enum ContentType { Application, Pdf, Zip }
        public DateTime SubmissionTime { get; set; }
        [ForeignKey(nameof(Course))]
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(Student))]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
