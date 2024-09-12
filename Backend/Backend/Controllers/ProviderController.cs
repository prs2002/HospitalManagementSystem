using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProviderById(string id)
        {
            var provider = await _providerService.GetProviderById(id);
            if (provider == null)
                return NotFound();

            return Ok(provider);
        }

        [HttpPut("{providerId}/availability")]
        public async Task<IActionResult> UpdateProviderAvailability(string providerId, List<Availability> availability)
        {
            var updatedProvider = await _providerService.UpdateProviderAvailability(providerId, availability);
            if (updatedProvider == null)
                return NotFound();

            return Ok(updatedProvider);
        }
    }
}
