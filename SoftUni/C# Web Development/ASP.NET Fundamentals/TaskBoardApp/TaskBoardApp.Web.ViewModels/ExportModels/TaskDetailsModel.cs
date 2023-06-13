namespace TaskBoardApp.Web.ViewModels.ExportModels
{
    using TaskBoardApp.ViewModels.ExportModels;
    public class TaskDetailsModel : TaskExportModel
    {
        public string CreatedOn { get; set; } = null!;

        public string Board { get; set; } = null!;
    }
}
