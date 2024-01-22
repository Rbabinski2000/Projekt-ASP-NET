using Data;
using Data.Entities;
using Projekt_ASP_NET.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Projekt_ASP_NET.Services
{
    public class MemoryGuideService : IGuideService
    {
        private AppDbContext _context;

        public MemoryGuideService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddGuide(GuideEntity guide)
        {
            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            GuideEntity? find = await _context.Guides.FindAsync(id);
            if (find != null)
            {
                _context.Guides.Remove(find);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GuideEntity>> FindAll()
        {
            return await _context.Guides
                .Include(g => g.Address)
                .ToListAsync();
        }



        public async Task<GuideEntity?> FindById(int id)
        {

            var model = await _context.Guides.FindAsync(id);
            model.Address = await _context.Address.FindAsync(model.AddressId);
            return model;

        }

        public async Task Update(GuideEntity guide)
        {
            _context.Guides.Update(guide);
            await _context.SaveChangesAsync();
        }



        public async Task<List<AddressEntity>> FindAllAddressForVieModel()
        {
            return await _context.Address.ToListAsync();

        }
    }
}
