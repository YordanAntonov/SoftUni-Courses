using Library.Data;
using Library.Models.Export;
using Library.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Library.Data.Models;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<AllBookView>> AllAsync()
        {
            var books = await context
                .Books
                .Select(b => new AllBookView()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                })
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<ViewCategory>> GetCategoriesAsync()
        {
            IEnumerable<ViewCategory> categories = await context
                .Categories
                .Select(c => new ViewCategory()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }

        public async Task AddToCollectionAsync(string id, AllBookView model)
        {
            bool alreadyAdded = await context.IdentityUserBooks
                .AnyAsync(b => b.BookId == model.Id && b.CollectorId == id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook()
                {
                    BookId = model.Id,
                    CollectorId = id
                };

                await context.IdentityUserBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
            }

            //var model = new ViewAddBookModel
            //{
            //    Title = book.Title,
            //    Author = book.Author,
            //    Description = book.Description,
            //    Rating = book.Rating,
            //    CategoryId = book.CategoryId,
            //    Url = book.ImageUrl,
            //    Categories = await this.GetCategoriesAsync()
            //};

        }

        public async Task<AllBookView?> GetBookByIdAsync(int id)
        {
            return await context.Books
                .Where(b => b.Id == id)
                .Select(b => new AllBookView()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                }).FirstOrDefaultAsync();
        }

        public async Task<ViewAddBookModel> ViewAddBookAsync()
        {
            var model = new ViewAddBookModel()
            {
                Categories = await GetCategoriesAsync()
            };

            return model;
        }

        public async Task AddBookAsync(ViewAddBookModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
                Rating = model.Rating,
                ImageUrl = model.Url,
                CategoryId = model.CategoryId,
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExportMyView>> MineBooksAsync(string userId)
        {
            var books = await context.IdentityUserBooks
                .Where(iub => iub.CollectorId == userId)
                .Select(iub => new ExportMyView()
                {
                    Id = iub.BookId,
                    Title = iub.Book.Title,
                    Description = iub.Book.Description,
                    Author = iub.Book.Author,
                    Category = iub.Book.Category.Name,
                    ImageUrl = iub.Book.ImageUrl
                })
                .ToListAsync();

            return books;
        }

        public async Task RemoveFromCollection(AllBookView id, string userId)
        {

            var userBook = await context.IdentityUserBooks.FirstOrDefaultAsync(b => b.CollectorId == userId && b.BookId == id.Id);

            if (userBook != null)
            {
                context.IdentityUserBooks.Remove(userBook);
                await context.SaveChangesAsync();
            }

        }

        public async Task<EditView?> GetForEditAsync(int id)
        {
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.Id == id);


            if (book == null) throw new InvalidOperationException("Invalid Book.");


            var model = new EditView()
            {
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Rating = book.Rating,
                Categories = await GetCategoriesAsync(),
                Url = book.ImageUrl
            };

            return model;
        }

        public async Task SetForEditAsync(EditView model)
        {
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.Id == model.Id);

            if (book == null) throw new InvalidOperationException("Something went wrong, try again later.");

            book.Title = model.Title;
            book.Description = model.Description;
            book.Author = model.Author;
            book.Rating = model.Rating;
            book.ImageUrl = model.Url;
            book.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();
        }
    }
}
