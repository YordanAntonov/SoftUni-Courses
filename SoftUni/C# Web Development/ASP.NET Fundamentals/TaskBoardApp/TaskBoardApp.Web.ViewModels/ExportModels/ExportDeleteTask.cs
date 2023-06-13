namespace TaskBoardApp.Web.ViewModels.ExportModels
{
    public class ExportDeleteTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
    }
}
