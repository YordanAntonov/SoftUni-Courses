namespace TaskBoardApp.ViewModels.ExportModels
{
    public class BoardExportModel
    {
        public BoardExportModel()
        {
            Tasks = new List<TaskExportModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<TaskExportModel> Tasks { get; set; }
    }
}
