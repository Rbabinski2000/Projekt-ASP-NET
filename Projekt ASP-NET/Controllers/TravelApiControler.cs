using Data;
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

        [HttpGet]
        public IActionResult GetFiltered(string filter)
        {
            return Ok(_context.Travels
                .Where(o => o.Name.StartsWith(filter))
                .Select(o => new { o.Name, o.Id })
                .ToList());
        }
    }
}
