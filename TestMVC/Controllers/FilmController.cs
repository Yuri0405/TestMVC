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
            var result = _repository.GetFilm(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }
    }
}
