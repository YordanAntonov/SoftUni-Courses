using TaskBoardApp.Web.ViewModels.ExportModels.IndexPageViewModel;

namespace TaskBoardApp.Services.Data.Contracts
{
    public interface IHomeConfig
    {
        Task<HomeViewModel> GetCountAsync(bool isAuthenticated, string userId);
    }
}
