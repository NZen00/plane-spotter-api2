using PlaneSpotterApi.Models;
using PlaneSpotterApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneSpotterApi.Services
{
    public interface IAirlineSightingService
    {
        Task<IEnumerable<AirlineSighting>> GetAllSightingsAsync();

        Task<AirlineSightingDetails> GetSightingByIdAsync(int id);

        Task AddSightingAsync(AirlineSighting sighting);

        Task UpdateSightingAsync(AirlineSighting sighting);

        Task DeleteSightingAsync(int id);

        Task<IEnumerable<AirlineSighting>> SearchSightingsAsync(string query);
    }
}
