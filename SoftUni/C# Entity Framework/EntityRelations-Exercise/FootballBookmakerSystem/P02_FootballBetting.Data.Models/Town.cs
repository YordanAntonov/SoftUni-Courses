using P02_FootballBetting.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Town
{
    public Town()
    {
        this.Teams = new HashSet<Team>();
    }

    [Key]
    public int TownId { get; set; }

    [Required]
    [MaxLength(EntityLength.TownNameMaxLength)]
    public string Name { get; set; } = null!;

    // TODO: Set up the foreign key
    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }

    public Country Country { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = null!;
}
