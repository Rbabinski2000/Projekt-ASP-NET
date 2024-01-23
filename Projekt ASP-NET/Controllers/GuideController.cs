using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_NET.Interfaces;
using Projekt_ASP_NET.Models;
using System.Diagnostics;

namespace Projekt_ASP_NET.Controllers
{
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;


        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [AllowAnonymous]
        public IActionResult IndexGuide()
        {
            return View(_guideService.FindAll());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateGuide()
        {
            ViewBag.AddressList = _guideService.FindAllAddressForVieModel().Result;
            return View();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult CreateGuide(GuideEntity model)
        {
            if (ModelState.IsValid)
            {

                _guideService.AddGuide(model);
                return RedirectToAction("IndexGuide");
            }
            else
            {
                return View(model);
            }

        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateAddress()
        {

            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult CreateAddress(AddressEntity model)
        {
            if (ModelState.IsValid)
            {

                _guideService.AddAddress(model);
                return RedirectToAction("CreateGuide");
            }
            else
            {
                return View(model);
            }

        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {

            ViewBag.AddressList = _guideService.FindAllAddressForVieModel().Result;
            return View(_guideService.FindById(id).Result);

        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(GuideEntity model)
        {
            if (ModelState.IsValid)
            {
                _guideService.Update(model);
                return RedirectToAction("IndexGuide");
            }
            else
            {
                return View(model);
            }
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            return View(_guideService.FindById(id).Result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_guideService.FindById(id).Result);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(GuideEntity model)
        {
            if (ModelState.IsValid)
            {
                _guideService.Delete(model.Id);
                return RedirectToAction("IndexGuide");
            }
            else
            {
                return View(model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
