using P02_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    public Student()
    {
        this.Homeworks = new HashSet<Homework>();

        this.StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }


    [Required]
    [MaxLength(Lenghts.NameMaxSize)]
    public string Name { get; set; } = null!;


    [MaxLength(Lenghts.PhoneNumberMaxSize)]
    public string? PhoneNumber { get; set; }


    public DateTime RegisteredOn { get; set; }


    public DateTime? Birthday { get; set; }

    //TODO: Add the colection of homeworks
    public virtual ICollection<Homework> Homeworks { get; set; }
    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}