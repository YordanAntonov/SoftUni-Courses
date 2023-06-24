namespace Homies.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using static Homies.Common.EntityConstraints;
    public class AddEventViewModel
    {
        [Required]
        [StringLength(EventNameMaxChar, MinimumLength = EventNameMinChar)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxChar, MinimumLength = EventDescriptionMinChar)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel>? Types { get; set; }
    }
}
