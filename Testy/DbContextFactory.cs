using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Microsoft.EntityFrameworkCore;
using System;
using Data.Entities;

namespace Tests
{
    public static class DbContextFactory
    {
        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unikalna nazwa bazy danych w pamięci
                .Options;

            var context = new AppDbContext();

            // Dodaj przykładowe dane
            SeedSampleData(context);

            return context;
        }

        private static void SeedSampleData(AppDbContext context)
        {
            // Dodajemy przykładowe adresy
            context.Address.AddRange(
                new AddressEntity { Id = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                new AddressEntity { Id = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
            );

            // Dodajemy przykładowe guidy
            context.Guides.AddRange(
                new GuideEntity { Id = 1, Name = "Grzegorz", Surname = "Drewniak", Pesel = "13424234123", AddressId = 1 },
                new GuideEntity { Id = 2, Name = "Tomasz", Surname = "Drewniak", Pesel = "13424234567", AddressId = 1 }
            );

            // Dodajemy przykładowe wycieczki
            context.Travels.AddRange(
                new TravelEntity
                {
                    Id = 1,
                    Name = "Niezapomniana Podróż-Kair",
                    StartDate = DateTime.Parse("01/02/2012"),
                    EndDate = DateTime.Parse("10/02/2012"),
                    StartPlace = "Warszawa",
                    EndPlace = "Kair",
                    Participants = "Kamil,Dawid,Michał",
                    GuideId = 1,
                    Created = DateTime.Now
                },
                new TravelEntity
                {
                    Id = 2,
                    Name = "Niezapomniana Podróż-Egipt",
                    StartDate = DateTime.Parse("01/02/2013"),
                    EndDate = DateTime.Parse("10/02/2013"),
                    StartPlace = "Kraków",
                    EndPlace = "Egipt",
                    Participants = "Kamil,Dawid,Gabryś",
                    GuideId = 2,
                    Created = DateTime.Now
                }
            );

            context.SaveChanges();
        }
    }
}