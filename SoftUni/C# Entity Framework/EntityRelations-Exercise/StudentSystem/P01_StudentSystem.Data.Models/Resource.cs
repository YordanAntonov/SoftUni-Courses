using P02_StudentSystem.Data.Common;
using P02_StudentSystem.Data.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(Lenghts.ResourceNameLenght)]
        public string Name { get; set; } = null!;

        public string Url { get; set; } = null!;

        public ResourceType ResourceType { get; set; }

        //Add the relation here
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public Course Course { get; set; } = null!;
    }
}
