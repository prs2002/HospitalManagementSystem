using Backend.Models;

namespace Backend.Service
{
    public interface IProviderService
    {
        Task<Provider> GetProviderById(string id);
        Task<Provider> UpdateProviderAvailability(string providerId, List<Availability> availability);
    }
}
