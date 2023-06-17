using Library.Models.Export;
using Library.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using static Library.Extensions.ClaimsPrincipalExtension;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.AllAsync();

            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All", "Book");
            }

            string userId = User.GetId();

            await bookService.AddToCollectionAsync(userId, book);

            return RedirectToAction("All", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await bookService.ViewAddBookAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ViewAddBookModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> Mine()
        {
            string userId = User.GetId();

            var model = await bookService.MineBooksAsync(userId);

            return View(model);
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            string idUser = User.GetId();
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("Mine", "Books");
            }

            await bookService.RemoveFromCollection(book, idUser);

            return RedirectToAction("Mine", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await bookService.GetForEditAsync(id);

                return View(model);
            }
            catch (InvalidOperationException ioe)
            {
                ModelState.AddModelError("Invalid","Eror 404...");

                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.SetForEditAsync(model);

            return RedirectToAction("Mine", "Book");
        }


    }
}
