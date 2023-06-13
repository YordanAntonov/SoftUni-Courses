namespace TaskBoardApp.Data.Models
{

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static TaskBoardApp.Data.Common.EntityConstraints;

    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; }

        public virtual Board? Board { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public IdentityUser Owner { get; set; } = null!;
    }
}
