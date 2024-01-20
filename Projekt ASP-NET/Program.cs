using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data;
using Projekt_ASP_NET.Interfaces;
using Projekt_ASP_NET.Services;
namespace Projekt_ASP_NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddTransient<ITravelService, MemoryTravelService>(); //service

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

           
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //builder.Services.AddSingleton<ITravelService, MemoryTravelService>();// do service

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Travel}/{action=Index}/{id?}");

            app.Run();
        }
    }
}