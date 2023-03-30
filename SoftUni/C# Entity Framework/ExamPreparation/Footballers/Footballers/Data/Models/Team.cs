using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            TeamsFootballers = new List<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EntityLengths.TeamNameMaxLength, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EntityLengths.NationalityMaxLength, MinimumLength = 2)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = null!;

    }
}
