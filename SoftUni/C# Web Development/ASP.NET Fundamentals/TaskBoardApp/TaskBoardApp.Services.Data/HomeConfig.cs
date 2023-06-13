namespace TaskBoardApp.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data;
    using TaskBoardApp.Services.Data.Contracts;
    using TaskBoardApp.Web.ViewModels.ExportModels.IndexPageViewModel;

    public class HomeConfig : IHomeConfig
    {
        private readonly TaskBoardAppDbContext context;

        public HomeConfig(TaskBoardAppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<HomeViewModel> GetCountAsync(bool isAuthenticated, string userId)
        {
            var taskBoards = await this.context.Boards
                                        .Select(b => b.Name)
                                        .Distinct().ToListAsync();

            var taskCounts = new List<HomeBoardModel>();
            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = await this.context.Tasks
                                             .Where(t => t.Board.Name == boardName)
                                             .CountAsync();

                taskCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TaskCount = tasksInBoard
                });
            }

            var userTasks = -1;

            if (isAuthenticated)
            {
                userTasks = await this.context.Tasks
                                              .Where(u => u.OwnerId == userId)
                                              .CountAsync();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = await this.context.Tasks.CountAsync(),
                BoardsWithTasksCount = taskCounts,
                UserTaskCount = userTasks
            };

            return homeModel;
        }
    }
}
