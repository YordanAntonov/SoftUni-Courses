namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Homies.Common.EntityConstraints;
    public class Type
    {
        public Type()
        {
            Events = new List<Event>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxChar)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
