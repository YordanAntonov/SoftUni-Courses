using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityConstraints;

namespace Library.Models.Export
{
    public class ViewCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
