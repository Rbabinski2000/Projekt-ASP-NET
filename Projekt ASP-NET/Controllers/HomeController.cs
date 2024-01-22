using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_NET.Models;

namespace Projekt_ASP_NET.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Welcome()
        {
            ViewData["Visit"] = Response.HttpContext.Items[LastVisitCookie.CookieName];
            return View();
        }
    }
}
