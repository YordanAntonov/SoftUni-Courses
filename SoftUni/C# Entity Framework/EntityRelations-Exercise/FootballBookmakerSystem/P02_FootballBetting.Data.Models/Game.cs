using Microsoft.EntityFrameworkCore.ChangeTracking;
using P02_FootballBetting.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Game
{
    public Game()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();

        this.Bets = new HashSet<Bet>();
    }

    [Key]
    public int GameId { get; set; }

    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }

    public virtual Team HomeTeam { get; set; } = null!;

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }

    public virtual Team AwayTeam { get; set; } = null!;

    public byte HomeTeamGoals { get; set; }

    public byte AwayTeamGoals { get; set; }

    public DateTime DateTime { get; set; }

    public double HomeTeamBetRate { get; set; }

    public double AwayTeamBetRate { get; set; }

    public double DrawBetRate { get; set; }

    [Required]
    [MaxLength(EntityLength.GameResultMaxLength)]
    public string Result { get; set; } = null!;

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = null!;
    public virtual ICollection<Bet> Bets { get; set; } = null!;

}
