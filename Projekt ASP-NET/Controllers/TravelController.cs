using Microsoft.AspNetCore.Mvc;
using Projekt_ASP_NET.Models;
using System.Diagnostics;
using Projekt_ASP_NET.Enums;
using System;
using Projekt_ASP_NET.Interfaces;

namespace Projekt_ASP_NET.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;
        static Dictionary<int, Travel> _travels = new Dictionary<int, Travel>();

        static DateTime tempD1 = new DateTime(2022, 10, 10);
        static DateTime tempD2 = new DateTime(2022, 10, 15);
        static Travel tt = new Travel();

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        public IActionResult Index()
        {
            if (_travels.Count() == 0)
            {
                tt.Id = 0;
                tt.Name = "Egipt";
                tt.StartPlace = "Kraków";
                tt.EndPlace = "Warszawa";
                tt.StartDate = tempD1;
                tt.EndDate = tempD2;
                tt.Participants = "Kamil";
                tt.Guide = Guides.Grzegorz;
                tt.Created= DateTime.Now;
                 _travels.Add(0,tt);
            }
            return View(_travels.Values.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Travel model)
        {
            if (ModelState.IsValid)
            {
                int id = _travels.Keys.Count != 0 ? _travels.Keys.Max() : 0;
                model.Id = id+1;
                model.Created=DateTime.Now;
                _travels.Add(model.Id, model);
                

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

            if (_travels.Keys.Contains(id))
            {
                return View(_travels[id]);
            }
            else
            {
                return NotFound();
            };
        }
        [HttpPost]
        public IActionResult Update(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travels[model.Id] = model;
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Details(int id)
        {
            return View(_travels[id]);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_travels[id]);
        }
        [HttpPost]
        public IActionResult Delete(Travel model)
        {
            _travels.Remove(model.Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
