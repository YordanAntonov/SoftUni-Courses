using P02_StudentSystem.Data.Common;
using P02_StudentSystem.Data.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [MaxLength(Lenghts.MaxLinkLength)]
        public string Content { get; set; } = null!;

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        //ForeignKeys
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;

    }
}
