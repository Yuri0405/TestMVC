using Microsoft.AspNetCore.Mvc;
using TestMVC.Services;

namespace TestMVC.Controllers
{
    public class FilmController:Controller
    {
        private readonly DbRepository _repository;
        public FilmController(DbRepository dbRepository)
        {
            _repository = dbRepository;
        }

        public IActionResult FilmDetails(int id)
        {
            ViewData["AvaibleCategories"] = _repository.GetAllCategories();
            var result = _repository.GetFilm(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        public IActionResult SetFilmToCategory(int filmId, int categoryId)
        {
            _repository.SetFilmToCategory(filmId, categoryId);
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveFilmFromCategory(int filmId, int categoryId)
        {
            _repository.RemoveFilmFromCategory(filmId, categoryId);
            return Ok();
        }
    }
}
