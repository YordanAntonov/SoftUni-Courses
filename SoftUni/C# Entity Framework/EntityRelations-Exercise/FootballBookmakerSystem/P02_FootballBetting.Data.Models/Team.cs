﻿using P02_FootballBetting.Common;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    public Team()
    {
        this.HomeGames = new HashSet<Game>();

        this.AwayGames = new HashSet<Game>();

        this.Players = new HashSet<Player>();
    }

    [Key]
    public int TeamId { get; set; }

    [Required]
    [MaxLength(EntityLength.TeamNameLength)]
    public string Name { get; set; } = null!;

    [MaxLength(EntityLength.LogoUrlLength)]
    public string? LogoUrl { get; set; }

    [Required]
    [MaxLength(EntityLength.TeamInitialLength)]
    public string Initials { get; set; } = null!;

    public decimal Budget { get; set; }

    // TODO: Set up those foreign keys

    [Required]
    [ForeignKey(nameof(PrimaryKitColor))]
    public int PrimaryKitColorId { get; set; }

    public virtual Color PrimaryKitColor { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(SecondaryKitColor))]
    public int SecondaryKitColorId { get; set; }
    public virtual Color SecondaryKitColor { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }

    public virtual Town Town { get; set; } = null!;

    [InverseProperty(nameof(Game.HomeTeam))]
    public virtual ICollection<Game> HomeGames { get; set; } = null!;

    [InverseProperty(nameof(Game.AwayTeam))]
    public virtual ICollection<Game> AwayGames { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = null!;

}