namespace TaskBoardApp.Web.ViewModels.ExportModels.IndexPageViewModel
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }

        public List<HomeBoardModel> BoardsWithTasksCount { get; set; } = null!;

        public int UserTaskCount { get; set; }
    }
}
