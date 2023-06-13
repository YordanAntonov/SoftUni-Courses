namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using TaskBoardApp.Services.Data.Contracts;
    using TaskBoardApp.Utilities;

    public class HomeController : Controller
    {
        private readonly IHomeConfig config;
        public HomeController(IHomeConfig _config)
        {
            this.config = _config;
        }

        [ActionName("Index")]
        public async Task<IActionResult> PostCount()
        {
            bool isAuthenticated = this.User.Identity.IsAuthenticated;

            string userId = this.User.GetId();

            var homeModel = await this.config.GetCountAsync(isAuthenticated, userId);

            return View(homeModel);
        }

    }
}