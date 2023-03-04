
using P02_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Homeworks = new HashSet<Homework>();

            this.Resources = new HashSet<Resource>();

            this.StudentsCourses = new HashSet<StudentCourse>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(Lenghts.CourseNameLenght)]
        public string Name { get; set; } = null!;

        [MaxLength]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        //Add collection of the studentCourses
        //Collection of Resourcecs
        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
    }
}
