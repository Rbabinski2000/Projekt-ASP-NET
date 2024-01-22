using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

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
