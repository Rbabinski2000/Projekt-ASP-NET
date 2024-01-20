using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP_NET.Interfaces;
using Projekt_ASP_NET.Models;
using Data;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Travel> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<TravelEntity> FindAllGuidesForVieModel()
        {
            //return _context.Guides.ToList();
            throw new NotImplementedException();
        }

        public Travel? FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Travel travel)
        {
            throw new NotImplementedException();
        }
    }
}
