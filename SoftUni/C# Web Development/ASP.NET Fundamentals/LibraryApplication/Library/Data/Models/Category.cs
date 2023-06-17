using System.ComponentModel.DataAnnotations;

using static Library.Common.EntityConstraints;

namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            Books = new List<Book>();   
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; } = null!;
    }
}
