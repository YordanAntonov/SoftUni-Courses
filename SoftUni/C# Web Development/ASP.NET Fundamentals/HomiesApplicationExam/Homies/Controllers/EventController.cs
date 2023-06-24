using Homies.Extensions;
using Homies.Services.Contracts;
using Homies.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        public async Task<IActionResult> All()
        {
            var models = await eventService.AllAsync();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await eventService.SelectAddFromAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string organizerId = User.GetId();

            await eventService.AddEventAsync(model, organizerId);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Join(int id)
        {
            string userId = User.GetId();

            var eventExists = await eventService.EventExists(id);

            if (!eventExists)
            {
                return RedirectToAction("All", "Event");
            }

            await eventService.JoinEventAsync(id, userId);

            return RedirectToAction("Joined", "Event");

        }

        public async Task<IActionResult> Joined()
        {
            string userId = User.GetId();

            var events = await eventService.JoinedAsync(userId);

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool idIsValid = await eventService.EventExists(id);
            if (!idIsValid)
            {
                return RedirectToAction("All", "Event");
            }


            var model = await eventService.ViewEditAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEventViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isValidId = await eventService.EventExists(id);

            if (!isValidId)
            {
                return RedirectToAction("All", "Event");
            }

            await eventService.EditEventAsync(model, id);


            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userId = User.GetId();

            bool idExists = await eventService.EventExists(id);

            if (!idExists)
            {
                return RedirectToAction("All", "Event");
            }

            await eventService.LeaveAsync(id, userId);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {
            bool idValid = await eventService.EventExists(id);

            if (!idValid)
            {
                return RedirectToAction("All", "Event");
            }

            var model = await eventService.DetailsAsync(id);

            return View(model);
        }
    }
}
