using System;
using Projekt_ASP_NET.Models;
using Data.Entities;


namespace Projekt_ASP_NET.Interfaces
{
    public interface ITravelService
    {
       
            public Task Add(TravelEntity travel);
            public Task AddGuide(GuideEntity guide);
            public Task Delete(int id);
            public Task Update(TravelEntity travel);
            public  Task<List<TravelEntity>> FindAll();
            Task<TravelEntity?> FindById(int id);
            Task<List<GuideEntity>> FindAllGuidesForVieModel();
        
    }
}
