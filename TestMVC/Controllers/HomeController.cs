using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMVC.Models;
using TestMVC.Services;
//using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbRepository _repository;

        public HomeController(ILogger<HomeController> logger, DbRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {        
            return View(_repository.GetAllFilms());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var filmToEdit = _repository.GetFilm(id);
            return View(filmToEdit);
        }

        public IActionResult FilmFormPartial(Film film)
        {
            return PartialView("_FilmForm");
        }

    }
}
