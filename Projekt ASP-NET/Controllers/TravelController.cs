using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_NET.Models;
using System.Diagnostics;
using Projekt_ASP_NET.Enums;
using System;
using Projekt_ASP_NET.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Projekt_ASP_NET.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;

        
        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        public IActionResult Index()
        {
            return View(_travelService.FindAll());
        }


        //[Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.GuideList = _travelService.FindAllGuidesForVieModel().Result;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TravelEntity model)
        {
            if (ModelState.IsValid)
            {
                
                _travelService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

        



        [HttpGet]
        public IActionResult Update(int id)
        {

            ViewBag.GuideList = _travelService.FindAllGuidesForVieModel().Result;
            return View(_travelService.FindById(id).Result);
            
        }
        [HttpPost]
        public IActionResult Update(TravelEntity model)
        {
            if (ModelState.IsValid)
            {
                _travelService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Details(int id)
        {
            return View(_travelService.FindById(id).Result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_travelService.FindById(id).Result);
        }
        [HttpPost]
        public IActionResult Delete(TravelEntity model)
        {
            _travelService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
