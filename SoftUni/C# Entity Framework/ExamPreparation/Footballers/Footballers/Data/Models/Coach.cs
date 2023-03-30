using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            Footballers = new List<Footballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityLengths.CoachMaxLength, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EntityLengths.NationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        public virtual ICollection<Footballer> Footballers { get; set; } = null!;

    }
}
