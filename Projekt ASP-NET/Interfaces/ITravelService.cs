using System;
using Projekt_ASP_NET.Models;
using Data.Entities;


namespace Projekt_ASP_NET.Interfaces
{
    public interface ITravelService
    {
       
            public int Add(Travel travel);
            void Delete(int id);
            void Update(Travel travel);
            public List<Travel> FindAll();
            Travel? FindById(int id);
            List<TravelEntity> FindAllGuidesForVieModel();
        
    }
}
