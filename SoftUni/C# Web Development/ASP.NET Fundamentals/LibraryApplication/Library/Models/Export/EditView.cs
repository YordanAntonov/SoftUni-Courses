using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityConstraints;

namespace Library.Models.Export
{
    public class EditView
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(AuthorNameMaxLength, MinimumLength = AuthorNameMinLength)]
        public string Author { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        [Range(RatingMinRate, RatingMaxRate)]
        public decimal Rating { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

        public IEnumerable<ViewCategory>? Categories { get; set; }
    }
}
