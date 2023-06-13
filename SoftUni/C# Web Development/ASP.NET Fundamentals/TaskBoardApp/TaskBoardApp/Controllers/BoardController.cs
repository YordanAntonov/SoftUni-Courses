namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using TaskBoardApp.Services.Data.Contracts;

    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService _boardService)
        {
            boardService = _boardService;
        }

        public async Task<IActionResult> All()
        {
            var boards = await this.boardService.AllAsync();

            return View(boards);
        }
    }
}
