namespace TaskBoardApp.Web.ViewModels.ImportModels
{
    using System.ComponentModel.DataAnnotations;
    using static TaskBoardApp.Data.Common.EntityConstraints;

    public class TaskImportModel
    {
        public TaskImportModel()
        {
            Boards = new List<BoardImportModel>();
        }

        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength,
            ErrorMessage = "Title should be atleast {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDescriptionMinLength, 
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<BoardImportModel?> Boards { get; set; }
    }
}
