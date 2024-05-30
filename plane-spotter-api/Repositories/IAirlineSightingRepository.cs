using PlaneSpotterApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneSpotterApi.Repositories
{
    public interface IAirlineSightingRepository
    {
        Task<IEnumerable<AirlineSighting>> GetAllAsync();

        Task<AirlineSightingDetails> GetByIdAsync(int id);

        Task AddAsync(AirlineSighting sighting);

        Task UpdateAsync(AirlineSighting sighting);

        Task DeleteAsync(int id);

        Task<IEnumerable<AirlineSighting>> SearchAsync(string query);
    }
}
