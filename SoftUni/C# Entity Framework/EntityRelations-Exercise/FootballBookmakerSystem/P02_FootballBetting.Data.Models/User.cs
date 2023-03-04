using P02_FootballBetting.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(EntityLength.UserNameMaxLength)]
    public string Username { get; set; } = null!;

    [Required]
    [MaxLength(EntityLength.UserPasswordMaxLength)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(EntityLength.UserEmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(EntityLength.PlayerNameLength)]
    public string Name { get; set; } = null!;

    [Required]
    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; } = null!;
}
