namespace ForumApp.ViewModels.Import
{
    using System.ComponentModel.DataAnnotations;

    using static ForumApp.Common.ModelConstants.PostModel.PostModelConstants;
    public class ImportPostModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
