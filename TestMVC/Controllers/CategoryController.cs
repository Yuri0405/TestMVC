using Microsoft.AspNetCore.Mvc;
using TestMVC.Models;
using TestMVC.Services;

namespace TestMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DbRepository _repository;
        private readonly CategoryService _categoryService;

        public CategoryController(DbRepository repository, CategoryService categoryService)
        {
            _repository = repository;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_repository.GetAllCategoriesDTO());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AvailableCategories = _repository.GetAllCategoriesDTO();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_categoryService.HasCircularDependency(category))
            {
                return BadRequest("Circular dependency detected");
            }

            _repository.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.AvailableCategories = _repository.GetAllCategoriesDTO();
            var categoryToEdit = _repository.GetCategory(id);
            return View(categoryToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (_categoryService.HasCircularDependency(category))
            {
                return BadRequest("Circular dependency detected");
            }
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
