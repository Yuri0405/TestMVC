using Microsoft.EntityFrameworkCore;

namespace TestMVC.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) {}

        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Category>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<FilmCategory>()
                .Property(fc => fc.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FilmCategory>()
                .HasKey(fc => new { fc.CategoryId, fc.FilmId });

            modelBuilder.Entity<FilmCategory>()
                .HasOne(fc => fc.Category)
                .WithMany(c => c.Films)
                .HasForeignKey(fc =>  fc.CategoryId);

            modelBuilder.Entity<FilmCategory>()
                .HasOne(fc => fc.Film)
                .WithMany(f => f.Categories)
                .HasForeignKey(fc => fc.FilmId);
        }
    }
}
