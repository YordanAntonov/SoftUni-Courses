using P02_FootballBetting.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class Country
{
    public Country()
    {
        Towns = new HashSet<Town>();
    }

    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(EntityLength.CountryNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Town> Towns { get; set; } = null!;
}
