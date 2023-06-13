
namespace TaskBoardApp.Services.Data
{

    using Microsoft.EntityFrameworkCore;

    using TaskBoardApp.Data;
    using TaskBoardApp.Services.Data.Contracts;
    using TaskBoardApp.Web.ViewModels.ExportModels;
    using TaskBoardApp.Web.ViewModels.ImportModels;

    using _Task = TaskBoardApp.Data.Models.Task;

    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext context;

        public TaskService(TaskBoardAppDbContext _context)
        {
            this.context = _context;
        }

        public async Task<bool> BoardExist(int id)
        {
            return await this.context.Boards.AnyAsync(b => b.Id == id);
        }

        public async Task<TaskImportModel> CreateAsync()
        {
            var task = new TaskImportModel()
            {
                Boards = await this.GetBoardsAsync()
            };

            return task;
        }

        public async Task CreateAsync(TaskImportModel model, string userId)
        {
            var newTask = new _Task()
            {
                Title = model.Title,
                Description = model.Description,
                OwnerId = userId,
                BoardId = model.BoardId,
                CreatedOn = DateTime.UtcNow
            };

            await this.context.Tasks.AddAsync(newTask);
            await this.context.SaveChangesAsync();
        }


        public async Task<IEnumerable<BoardImportModel>> GetBoardsAsync()
        {
            return await this.context
                .Boards
                .Select(b => new BoardImportModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();
        }

        public async Task<TaskDetailsModel> GetTaskDetailsAsync(int id)
        {
            TaskDetailsModel task = await this.context
                .Tasks
                .Select(task => new TaskDetailsModel()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Owner = task.Owner.Email,
                    CreatedOn = task.CreatedOn.ToString("f"),
                    Board = task.Board!.Name
                })
                .FirstAsync(t => t.Id == id);


            return task;

        }

        public async Task<TaskImportModel?> GetTaskForEditAsync(int id)
        {
            _Task? task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return null;
            }

            return new TaskImportModel()
            {
                Title = task.Title,
                Description = task.Description,
                Boards = await GetBoardsAsync(),
                BoardId = task.BoardId
            };
        }

        public async Task<bool> TaskExist(int id)
        {
            return await this.context.Tasks.AnyAsync(b => b.Id == id);
        }

        public async Task EditTaskAsync(TaskImportModel model, int id)
        {
            var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await this.context.SaveChangesAsync();
        }

        public async Task<ExportDeleteTask?> GetForDeleteAsync(int id)
        {
            var task = await this.context.Tasks.Select(t => new ExportDeleteTask()
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                OwnerId = t.OwnerId,
            }).FirstOrDefaultAsync(t => t.Id == id);

            return task;
        }

        public async Task DeleteTaskAsync(int id)
        {
            this.context.Remove(await context.Tasks.FirstAsync(t => t.Id == id));

            await this.context.SaveChangesAsync();
        }
    }
}
