namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using TaskBoardApp.Services.Data.Contracts;

    using TaskBoardApp.Web.ViewModels.ExportModels;
    using TaskBoardApp.Web.ViewModels.ImportModels;

    using TaskBoardApp.Utilities;

    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService _taskService)
        {
            this.taskService = _taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await this.taskService.CreateAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskImportModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await this.taskService.GetBoardsAsync();
                return View(model);
            }

            var boardExists = await this.taskService.BoardExist(model.BoardId);

            if (!boardExists)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board doesnot exist");

                model.Boards = await this.taskService.GetBoardsAsync();
                return View(model);
            }

            string currentUserId = this.User.GetId();

            await this.taskService.CreateAsync(model, currentUserId);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                TaskDetailsModel model
                    = await this.taskService.GetTaskDetailsAsync(id);

                return View(model);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool taskValid = await this.taskService.TaskExist(id);

            if (!taskValid)
            {
                ModelState.AddModelError("", "Selected Task Does not Exist");

                return BadRequest(ModelState);
            }

            var model = await this.taskService.GetTaskForEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskImportModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await taskService.GetBoardsAsync();

                return View(model);
            }

            var boardExists = await this.taskService.BoardExist(model.BoardId);

            if (!boardExists)
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board doesnot exist");

                model.Boards = await this.taskService.GetBoardsAsync();
                return View(model);
            }

            await this.taskService.EditTaskAsync(model, id);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await this.taskService.GetForDeleteAsync(id);

            if (model == null)
            {
                return BadRequest(ModelState);
            }

            string currentId = this.User.GetId();

            if (currentId != model.OwnerId)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteFull(int id)
        {
            try
            {
                await this.taskService.DeleteTaskAsync(id);

                return RedirectToAction("All", "Board");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Invalid Operation!");

                return RedirectToAction("All", "Board");
            }
        }
    }
}
