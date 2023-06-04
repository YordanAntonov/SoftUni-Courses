namespace ForumApp.Services.Contracts
{
    using ForumApp.ViewModels.Export;
    using ForumApp.ViewModels.Import;

    public interface IPostService
    {
        Task<ICollection<PostViewModel>> AllAsync();

        Task AddAsync(ImportPostModel model);

        Task<PostViewModel> GetEditAsync(string id);

        Task EditAsync(string id, PostViewModel model);

        Task DeleteAsync(string id);
    }
}
