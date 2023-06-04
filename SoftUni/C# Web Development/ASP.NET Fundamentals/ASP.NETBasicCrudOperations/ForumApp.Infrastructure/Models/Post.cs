namespace ForumApp.Infrastructure.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static ForumApp.Common.ModelConstants.PostModel.PostModelConstants;

    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [Comment("Guid")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Content")]
        public string Content { get; set; } = null!;
    }
}
