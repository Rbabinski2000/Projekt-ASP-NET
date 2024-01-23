using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP_NET.Interfaces;
using Projekt_ASP_NET.Models;

namespace Projekt_ASP_NET.Controllers
{
    [Route("api/Travel")]
    [ApiController]
    public class TravelApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TravelApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetFilteredList")]
        public IActionResult GetTravelListFiltered(string filter) {

            filter = filter.ToLower();
            if (filter == "null")
            {

                var filteredTravels = _context.Travels
                    .ToList();

                return Ok(filteredTravels);
            }
            else
            {
                var filteredTravels =  _context.Travels
                    .Where(g => g.Name.ToLower().StartsWith(filter))
                    .ToList();

                return Ok(filteredTravels);
            }
        }
        [HttpGet("GetFiltered")]
        public IActionResult GetFiltered(string filter)
        {
            filter = filter.ToLower();
            if (filter=="null")
            {
                
                var filteredGuides = _context.Guides
                    .ToList();

                return Ok(filteredGuides);
            }
            else
            {
                var filteredGuides = _context.Guides
                    .Where(g => g.Name.ToLower().StartsWith(filter))
                    .ToList();

                return Ok(filteredGuides);
            }
        }
    }
}
