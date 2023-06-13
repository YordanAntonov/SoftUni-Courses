namespace TaskBoardApp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static TaskBoardApp.Data.Common.EntityConstraints;

    public class Board
    {
        public Board()
        {
            Tasks = new List<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }

    }
}