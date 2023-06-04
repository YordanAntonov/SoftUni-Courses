namespace ForumApp.Controllers
{
    using ForumApp.Services.Contracts;
    using ForumApp.ViewModels.Export;
    using ForumApp.ViewModels.Import;
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        public async Task<IActionResult> All()
        {
            ICollection<PostViewModel> posts = await postService.AllAsync();

            return View(posts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImportPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await postService.AddAsync(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected Error Occured!");
                return View(model);
            }

            return RedirectToAction("All", "Post");
        }

        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                PostViewModel post = await this.postService.GetEditAsync(id);

                return View(post);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Post");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostViewModel model)
        {
            try
            {
                await postService.EditAsync(id, model);

                return RedirectToAction("All", "Post");
            }
            catch(Exception)
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this.postService.DeleteAsync(id);

                return RedirectToAction("All", "Post");
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Post");
            }
        }
    }
}
