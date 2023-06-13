namespace TaskBoardApp.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TaskBoardApp.Data;
    using TaskBoardApp.Services.Data.Contracts;
    using TaskBoardApp.ViewModels.ExportModels;
    public class BoardService : IBoardService
    {
        private readonly TaskBoardAppDbContext context;

        public BoardService(TaskBoardAppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<BoardExportModel>> AllAsync()
        {
            return await context.Boards.Select(x => new BoardExportModel()
            {
                Id = x.Id,
                Name = x.Name,
                Tasks = x.Tasks.Select(x => new TaskExportModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Owner = x.Owner.Email
                })
            }).ToListAsync();             
        }
    }
}
