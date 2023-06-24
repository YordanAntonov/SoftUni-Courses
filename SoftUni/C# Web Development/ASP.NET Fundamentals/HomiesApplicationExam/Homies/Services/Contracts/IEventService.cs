using Homies.ViewModels;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> AllAsync();

        Task<IEnumerable<TypeViewModel>> GetTypesAsync();

        Task AddEventAsync(AddEventViewModel model, string organizerId);

        Task<AddEventViewModel> SelectAddFromAsync();

        Task JoinEventAsync(int id, string userId);

        Task<bool> EventExists(int id);

        Task<IEnumerable<JoinViewModel>> JoinedAsync(string userId);

        Task<AddEventViewModel> ViewEditAsync(int id);

        Task EditEventAsync(AddEventViewModel model, int id);

        Task LeaveAsync(int id, string userId);

        Task<DetailsView> DetailsAsync(int id);
    }

}
