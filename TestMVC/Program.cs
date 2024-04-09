using Microsoft.EntityFrameworkCore;
using TestMVC.Models;
using TestMVC.Services;

namespace TestMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDBContext>(options => 
            options.UseInMemoryDatabase(databaseName: "InMemDB")
            );

            builder.Services.AddTransient<DbRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AppDBContext>();
                SeedData.Initialize(dbContext);
            }

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}