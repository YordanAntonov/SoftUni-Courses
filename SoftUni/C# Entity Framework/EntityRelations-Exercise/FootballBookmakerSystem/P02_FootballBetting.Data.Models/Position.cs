using P02_FootballBetting.Common;

using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class Position
{
    public Position()
    {
        this.Players = new HashSet<Player>();
    }

    [Key]
    public int PositionId { get; set; }

    [Required]
    [MaxLength(EntityLength.PositionNameLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = null!;
}
