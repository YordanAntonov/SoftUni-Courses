namespace TaskBoardApp.Services.Data.Contracts
{
    using TaskBoardApp.ViewModels.ExportModels;
    public interface IBoardService
    {
        Task<IEnumerable<BoardExportModel>> AllAsync();
    }
}
