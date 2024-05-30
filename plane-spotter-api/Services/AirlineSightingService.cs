using PlaneSpotterApi.Models;
using PlaneSpotterApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneSpotterApi.Services
{
    public class AirlineSightingService : IAirlineSightingService
    {
        private readonly IAirlineSightingRepository _repository;

        public AirlineSightingService(IAirlineSightingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AirlineSighting>> GetAllSightingsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AirlineSightingDetails> GetSightingByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddSightingAsync(AirlineSighting sighting)
        {
            await _repository.AddAsync(sighting);
        }

        public async Task UpdateSightingAsync(AirlineSighting sighting)
        {
            await _repository.UpdateAsync(sighting);
        }

        public async Task DeleteSightingAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AirlineSighting>> SearchSightingsAsync(string query)
        {
            return await _repository.SearchAsync(query);
        }
    }
}
