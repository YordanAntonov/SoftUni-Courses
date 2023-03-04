using P02_FootballBetting.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Player
{
    public Player()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
    }

    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(EntityLength.PlayerNameLength)]
    public string Name { get; set; } = null!;

    [Required]
    public byte SquadNumber { get; set; }

    // TODO: Fic the foreignKeys
    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    public virtual Position Position { get; set; } = null!;

    public bool IsInjured { get; set; }

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;
}
