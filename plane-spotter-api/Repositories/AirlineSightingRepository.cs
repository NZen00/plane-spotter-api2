using Microsoft.EntityFrameworkCore;
using PlaneSpotterApi.Context;
using PlaneSpotterApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotterApi.Repositories
{
    public class AirlineSightingRepository : IAirlineSightingRepository
    {
        private readonly PlaneSpotterContext _context;

        public AirlineSightingRepository(PlaneSpotterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AirlineSighting>> GetAllAsync()
        {
            return await _context.AirlineSightings.ToListAsync();
        }

        //public async Task<AirlineSighting> GetByIdAsync(int id)
        //{
        //    return await _context.AirlineSightings.FirstOrDefaultAsync(s => s.Id == id);
        //}

        public async Task<AirlineSightingDetails> GetByIdAsync(int id)
        {
            var sighting = await _context.AirlineSightings
                .Where(s => s.Id == id)
                .Select(s => new AirlineSightingDetails
                {
                    Id = s.Id,
                    Name = s.Name,
                    ShortName = s.ShortName,
                    AirlineCode = s.AirlineCode,
                    Location = s.Location,
                    CreatedDate = s.CreatedDate,
                    Active = s.Active,
                    Delete = s.Delete,
                    CreatedUserId = s.CreatedUserId,
                    ModifiedUserId = s.ModifiedUserId,
                    CreatedUser = s.CreatedUser != null ? new UserDetails
                    {
                        Username = s.CreatedUser.Username,
                        Email = s.CreatedUser.Email
                    } : null,
                    ModifiedUser = s.ModifiedUser != null ? new UserDetails
                    {
                        Username = s.ModifiedUser.Username,
                        Email = s.ModifiedUser.Email
                    } : null
                })
                .FirstOrDefaultAsync();

            return sighting;
        }

        public async Task AddAsync(AirlineSighting sighting)
        {
            await _context.AirlineSightings.AddAsync(sighting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AirlineSighting sighting)
        {
            _context.AirlineSightings.Update(sighting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sighting = await _context.AirlineSightings.FindAsync(id);
            if (sighting != null)
            {
                _context.AirlineSightings.Remove(sighting);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AirlineSighting>> SearchAsync(string query)
        {
            return await _context.AirlineSightings
                .Where(s => s.Name.Contains(query) || s.ShortName.Contains(query) || s.AirlineCode.Contains(query))
                .ToListAsync();
        }
    }

    public class AirlineSightingDetails
    {
        public int Id { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string AirlineCode { get; set; }
        public string Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }
        public bool Delete { get; set; }

        public UserDetails? CreatedUser { get; set; }
        public UserDetails? ModifiedUser { get; set; }
    }

    public class UserDetails
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }

}
