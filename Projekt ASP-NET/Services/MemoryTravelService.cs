using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP_NET.Interfaces;
using Projekt_ASP_NET.Models;
using Data;
using Data.Entities;
using Projekt_ASP_NET.Mapper;

namespace Projekt_ASP_NET.Services
{
    
    public class MemoryTravelService : ITravelService
    {
        private AppDbContext _context;

        public MemoryTravelService(AppDbContext context) 
        {  
           _context = context; 
        }

        public int Add(Travel travel)
        {
            var e = _context.Travels.Add(TravelMapper.ToEntity(travel));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            TravelEntity? find = _context.Travels.Find(id);
            if (find != null)
            {
                _context.Travels.Remove(find);
            }
        }

        public List<Travel> FindAll()
        {
            return _context.Travels.Select(e => TravelMapper.FromEntity(e)).ToList();
        }

        public List<GuideEntity> FindAllGuidesForVieModel()
        {
            return _context.Guides.ToList();
            
        }

        public Travel? FindById(int id)
        {
            return TravelMapper.FromEntity(_context.Travels.Find(id));
        }

        public void Update(Travel travel)
        {
            _context.Travels.Update(TravelMapper.ToEntity(travel));
        }
    }
}
