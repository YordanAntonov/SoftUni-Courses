namespace TaskBoardApp.Services.Data.Contracts
{
    using TaskBoardApp.Web.ViewModels.ExportModels;
    using TaskBoardApp.Web.ViewModels.ImportModels;

    public interface ITaskService
    {
        Task<TaskImportModel> CreateAsync();

        Task<IEnumerable<BoardImportModel>> GetBoardsAsync();

        Task CreateAsync(TaskImportModel model, string userId);

        Task<bool> BoardExist(int id);

        Task<bool> TaskExist(int id);

        Task<TaskDetailsModel> GetTaskDetailsAsync(int id);

        Task<TaskImportModel?> GetTaskForEditAsync(int id);

        Task EditTaskAsync(TaskImportModel model, int id);

        Task<ExportDeleteTask?> GetForDeleteAsync(int id);

        Task DeleteTaskAsync(int id);
    }
}
