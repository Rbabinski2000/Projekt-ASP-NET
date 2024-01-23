using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Projekt_ASP_NET.Interfaces;
using Projekt_ASP_NET.Models;
using Data;
using Data.Entities;

namespace Projekt_ASP_NET.Services
{
    
    public class MemoryTravelService : ITravelService
    {
        private AppDbContext _context;

        public MemoryTravelService(AppDbContext context) 
        {  
           _context = context; 
        }

        public async Task Add(TravelEntity travel)
        {
            _context.Travels.Add(travel);
            await _context.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            TravelEntity? find = await _context.Travels.FindAsync(id);
            if (find != null)
            {
                _context.Travels.Remove(find);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TravelEntity>> FindAll()
        {
            return await _context.Travels
                .Include(g=>g.Guide)
                .ToListAsync();
        }

        public async Task<List<GuideEntity>> FindAllGuidesForVieModel()
        {
            return await _context.Guides.ToListAsync();
            
        }
        

        public async Task<TravelEntity?> FindById(int id)
        {

            var model= await _context.Travels.FindAsync(id);
            model.Guide= await _context.Guides.FindAsync(model.GuideId);
            return model;

        }

        public async Task Update(TravelEntity travel)
        {
            _context.Travels.Update(travel);
            await _context.SaveChangesAsync();
        }
        public PagingList<TravelEntity> FindPage(int page, int size)
        {
            return PagingList<TravelEntity>.Create(
                    (p, s) => _context.Travels
                            .OrderBy(b => b.Name)
                            .Skip((p - 1) * size)
                            .Take(s)
                            .ToList(),
                    _context.Travels.Count(),
                    page,
                    size);
        }
    }
}
