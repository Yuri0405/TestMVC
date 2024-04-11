using Microsoft.EntityFrameworkCore;
using TestMVC.Models;
using TestMVC.Models.DTO;

namespace TestMVC.Services
{
    public class DbRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly CategoryService _categoryService;
        public DbRepository(AppDBContext dBContext) 
        {
            _dbContext = dBContext;
        
        }

        #region CRUD for Movies
        public List<Film> GetAllFilms()
        {
            var list = _dbContext.Films
                .Include(f => f.Categories)
                .ThenInclude(cf => cf.Category)
                .ToList();

            return list;
        }

        public Film GetFilm(int id)
        {
            return _dbContext.Films
                .Include(f => f.Categories)
                .ThenInclude(cf => cf.Category)
                .FirstOrDefault(film => film.Id == id);
        }

        public void CreateFilm(Film film)
        {
            _dbContext.Films.Add(film);
            _dbContext.SaveChanges();
        }

        public void EditFilm(Film film)
        {
            var filmToEdit = _dbContext.Films.FirstOrDefault(f => f.Id == film.Id);
            
            filmToEdit.Name = film.Name;
            filmToEdit.Director = film.Director;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var filmToDelete = _dbContext.Films.FirstOrDefault(f => f.Id == id);
            _dbContext.Films.Remove(filmToDelete);
            _dbContext.SaveChanges();
        }
        #endregion

        #region CRUD for Categories

        public List<Category> GetAllCategories()
        {
            var list  = _dbContext.Categories.ToList();
            return list;
        }

        public Category GetCategory(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = _dbContext.Categories.FirstOrDefault(c => c.Id == category.Id);
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.ParentCategoryId = category.ParentCategoryId;

            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var categoryToDelete = _dbContext.Categories.FirstOrDefault(f => f.Id == id);
            _dbContext.Remove(categoryToDelete);
            _dbContext.SaveChanges();
        }

        #endregion

        #region CRUD for Category_film
        public void SetFilmToCategory(int filmId,int categoryId)
        {
            _dbContext.Add(new FilmCategory { FilmId = filmId,CategoryId = categoryId });
            _dbContext.SaveChanges();
        }

        public void RemoveFilmFromCategory(int filmId, int categoryId)
        {
            var categoryToRemove = _dbContext.FilmCategories.FirstOrDefault(r => r.FilmId == filmId && r.CategoryId == categoryId);
            _dbContext.Remove(categoryToRemove);
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
