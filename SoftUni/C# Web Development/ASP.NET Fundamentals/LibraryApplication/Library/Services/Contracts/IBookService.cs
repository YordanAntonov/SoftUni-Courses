using Library.Models.Export;

namespace Library.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookView>> AllAsync();

        Task AddToCollectionAsync(string id, AllBookView model);

        Task<IEnumerable<ViewCategory>> GetCategoriesAsync();

        Task<AllBookView?> GetBookByIdAsync(int id);

        Task<ViewAddBookModel> ViewAddBookAsync();

        Task AddBookAsync(ViewAddBookModel model);

        Task<IEnumerable<ExportMyView>> MineBooksAsync(string userId);

        Task RemoveFromCollection(AllBookView id, string userId);

        Task<EditView?> GetForEditAsync(int id);
        Task SetForEditAsync(EditView model);
    }
}
