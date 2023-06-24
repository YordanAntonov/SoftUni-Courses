using Homies.Data;
using Homies.Data.Models;
using Homies.Services.Contracts;
using Homies.ViewModels;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext _context)
        {
            this.context = _context;
        }

        public async Task AddEventAsync(AddEventViewModel model, string organizerId)
        {
            string format = "yyyy-MM-dd HH:mm";

            Event curEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                Start = DateTime.ParseExact(model.Start, format, CultureInfo.InvariantCulture),
                End = DateTime.ParseExact(model.Start, format, CultureInfo.InvariantCulture),
                TypeId = model.TypeId,
                CreatedOn = DateTime.UtcNow,
                OrganiserId = organizerId
            };

            await context.Events.AddAsync(curEvent);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> AllAsync()
        {
            var models = await context.Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd HH:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();

            return models;
        }

        public async Task<DetailsView> DetailsAsync(int id)
        {
            var curEvent = await context.Events
                .Select(e => new DetailsView()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString("yyyy-MM-dd HH:mm"),
                    End = e.End.ToString("yyyy-MM-dd HH:mm"),
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd HH:mm"),
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync(e => e.Id == id);

            

            return curEvent;
        }

        public async Task EditEventAsync(AddEventViewModel model, int id)
        {
            var currEvent = await context.Events.FirstOrDefaultAsync(e => e.Id == id);

            currEvent.Name = model.Name;
            currEvent.Description = model.Description;
            currEvent.Start = DateTime.UtcNow.AddDays(1);
            currEvent.End = DateTime.UtcNow.AddDays(10);
            currEvent.TypeId = model.TypeId;

            await context.SaveChangesAsync();
        }

        public async Task<bool> EventExists(int id)
        {
            return await context.Events.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        {
            var types = await context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            return types;
        }

        public async Task<IEnumerable<JoinViewModel>> JoinedAsync(string userId)
        {

            var events = await context.EventsParticipants
                .Where(e => e.HelperId == userId)
                .Select(e => new JoinViewModel()
                {
                    Id = e.EventId,
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString("yyyy-MM-dd HH:mm"),
                    Type = e.Event.Type.Name,
                    Organiser = e.Event.Organiser.UserName
                })
                .ToListAsync();

            return events;
        }

        public async Task JoinEventAsync(int id, string userId)
        {
            bool alreadyAdded = await context.EventsParticipants.AnyAsync(e => e.EventId == id && e.HelperId == userId);

            var curEvent = await context.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (!alreadyAdded)
            {
                var joinedEvent = new EventParticipant()
                {
                    EventId = id,
                    HelperId = userId
                };

                await context.EventsParticipants.AddAsync(joinedEvent);
                await context.SaveChangesAsync();
            }

        }

        public async Task LeaveAsync(int id, string userId)
        {
            var currEvent = await context.EventsParticipants.FirstOrDefaultAsync(e => e.EventId == id && e.HelperId == userId);

            context.EventsParticipants.Remove(currEvent);
            await context.SaveChangesAsync();
        }

        public async Task<AddEventViewModel> SelectAddFromAsync()
        {
            var model = new AddEventViewModel()
            {
                Types = await this.GetTypesAsync(),
            };

            return model;
        }

        public async Task<AddEventViewModel> ViewEditAsync(int id)
        {
            var currEvent = await context.Events.FirstOrDefaultAsync(e => e.Id == id);

            var model = new AddEventViewModel()
            {
                Name = currEvent.Name,
                Description = currEvent.Description,
                Start = currEvent.Start.ToString("yyyy-MM-dd HH:mm"),
                End = currEvent.End.ToString("yyyy-MM-dd HH:mm"),
                TypeId = currEvent.TypeId,
                Types = await this.GetTypesAsync(),
            };

            return model;     
        }


    }
}
