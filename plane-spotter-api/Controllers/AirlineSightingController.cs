using Microsoft.AspNetCore.Mvc;
using PlaneSpotterApi.Models;
using PlaneSpotterApi.Repositories;
using PlaneSpotterApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneSpotterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineSightingController : ControllerBase
    {
        private readonly IAirlineSightingService _service;

        public AirlineSightingController(IAirlineSightingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineSighting>>> GetAll()
        {
            var sightings = await _service.GetAllSightingsAsync();
            return Ok(sightings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineSightingDetails>> GetById(int id)
        {
            var sighting = await _service.GetSightingByIdAsync(id);
            if (sighting == null)
            {
                return NotFound();
            }
            return Ok(sighting);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AirlineSighting sighting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddSightingAsync(sighting);
            return CreatedAtAction(nameof(GetById), new { id = sighting.Id }, sighting);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AirlineSighting sighting)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSighting = await _service.GetSightingByIdAsync(id);
            if (existingSighting == null)
            {
                return NotFound();
            }

            //existingSighting.Name = sighting.Name;
            //existingSighting.ShortName = sighting.ShortName;
            //existingSighting.AirlineCode = sighting.AirlineCode;
            //existingSighting.Location = sighting.Location;
            //existingSighting.CreatedDate = sighting.CreatedDate;
            //existingSighting.ModifiedUserId = sighting.ModifiedUserId;

            var updatedSighting = new AirlineSighting
            {
                Id = existingSighting.Id,
                Name = sighting.Name,
                ShortName = sighting.ShortName,
                AirlineCode = sighting.AirlineCode,
                Location = sighting.Location,
                CreatedDate = sighting.CreatedDate,
                ModifiedUserId = sighting.ModifiedUserId,
                CreatedUserId = sighting.CreatedUserId,
            };

            await _service.UpdateSightingAsync(updatedSighting);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var sighting = await _service.GetSightingByIdAsync(id);
            if (sighting == null)
            {
                return NotFound();
            }

            await _service.DeleteSightingAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AirlineSighting>>> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Search query cannot be empty");
            }

            var sightings = await _service.SearchSightingsAsync(query);
            return Ok(sightings);
        }
    }
}
