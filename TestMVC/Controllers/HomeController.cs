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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Film film)
        {
            _repository.CreateFilm(film);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var filmToEdit = _repository.GetFilm(id);
            return View(filmToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Film film)
        {
            _repository.EditFilm(film);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult FilmFormPartial(Film film)
        {
            return PartialView("_FilmForm");
        }

    }
}
