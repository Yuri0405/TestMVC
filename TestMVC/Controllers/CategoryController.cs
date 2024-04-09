using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;
using TestMVC.Services;

namespace TestMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DbRepository _repository;

        public CategoryController(DbRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAllCategories());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _repository.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var categoryToEdit = _repository.GetCategory(id);
            return View(categoryToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _repository.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
