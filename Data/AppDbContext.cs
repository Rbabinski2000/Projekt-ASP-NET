using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        private string DbPath { get; set; }
        public DbSet<TravelEntity> Travels { get; set; }
        public DbSet<GuideEntity> Guides { get; set; }

        public AppDbContext()
        {
            var str = Environment.CurrentDirectory;
            str=str.Substring(0,str.LastIndexOf('\\') + 1);
            str = str + "Data";
            var folder = Path.Combine(str, "BazyDanych");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            DbPath = Path.Combine(folder, "Travels.db");
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite($"Data source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adamo",
                NormalizedUserName="ADAMO",
                Email = "adamo@micros.com",
                NormalizedEmail="ADAMO@MICROS.COM",
                EmailConfirmed = true
            };
            
            user.PasswordHash= ph.HashPassword(user, "1234Ab!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(
                    user
                ) ;
            
            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };
            adminRole.ConcurrencyStamp = adminRole.Id;

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    adminRole
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = adminRole.Id,
                        UserId= user.Id
                    }
                );
            

            modelBuilder.Entity<GuideEntity>()
                .OwnsOne(a => a.Address);
            modelBuilder.Entity<GuideEntity>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<TravelEntity>()
                .HasOne(g => g.Guide)
                .WithMany(t => t.Travels)
                .HasForeignKey(g => g.GuideId);

            


            modelBuilder.Entity<GuideEntity>().HasData(
                 new GuideEntity()
                 {
                     Id = 1,
                     Name = "Grzegorz",
                     Surname = "Drewniak",
                     Pesel = "13424234123",
                     
                 },
                 new GuideEntity()
                 {
                     Id = 2,
                     Name = "Tomasz",
                     Surname = "Drewniak",
                     Pesel = "13424234567",
                 }
             ); ;
            modelBuilder.Entity<TravelEntity>().HasData(
               new TravelEntity()
               {
                   Id = 1,
                   Name = "Niezapomniana Podróż-Kair",
                   StartDate = DateTime.Parse("01/02/2012"),
                   EndDate = DateTime.Parse("10/02/2012"),
                   StartPlace="Warszawa",
                   EndPlace="Kair",
                   Participants="Kamil,Dawid,Michał",
                   GuideId=1,
                   Created=DateTime.Now
               },
               new TravelEntity()
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
            modelBuilder.Entity<GuideEntity>()
               .OwnsOne(e => e.Address)
               .HasData(
                   new { GuideEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                   new { GuideEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
               );
        }

        
    }
}
