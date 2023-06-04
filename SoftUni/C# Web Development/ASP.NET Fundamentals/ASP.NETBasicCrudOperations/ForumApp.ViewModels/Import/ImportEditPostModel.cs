using System.ComponentModel.DataAnnotations;

using static ForumApp.Common.ModelConstants.PostModel.PostModelConstants;

namespace ForumApp.ViewModels.Import
{
    public class ImportEditPostModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
