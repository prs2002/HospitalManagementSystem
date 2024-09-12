using Backend.Models;
using Backend.Repositories;

namespace Backend.Service
{
    public class ProviderService : IProviderService
    {
        private readonly IRepo<Provider> _providerRepository;

        public ProviderService(IRepo<Provider> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<Provider> GetProviderById(string id)
        {
            return await _providerRepository.GetByIdAsync(id);
        }

        public async Task<Provider> UpdateProviderAvailability(string providerId, List<Availability> availability)
        {
            var provider = await _providerRepository.GetByIdAsync(providerId);
            if (provider != null)
            {
                provider.Availability = availability;
                await _providerRepository.UpdateAsync(providerId, provider);
            }
            return provider;
        }
    }
}
