using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_NET.Interfaces;

namespace Projekt_ASP_NET.Controllers
{
    public class GuideController : Controller
    {
        private readonly ITravelService _travelService;


        public GuideController(ITravelService travelService)
        {
            _travelService = travelService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateGuide()
        {
            ViewBag.GuideList = _travelService.FindAllGuidesForVieModel().Result;
            return View();
        }
        [HttpPost]
        public IActionResult CreateGuide(GuideEntity model)
        {
            if (ModelState.IsValid)
            {

                _travelService.AddGuide(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }
    }
}
