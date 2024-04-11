using Microsoft.EntityFrameworkCore;
using TestMVC.Models;

namespace TestMVC.Services
{
    public class CategoryService
    {
        private readonly AppDBContext _dbContext;

        public CategoryService( AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasCircularDependency(Category model)
        {
            // Get the parent category chain
            var parentChain = GetParentCategoryChain(model.ParentCategoryId);

            // Check if adding the current category creates a circular dependency
            return parentChain.Contains(model.Id);
        }

        private List<int> GetParentCategoryChain(int? categoryId)
        {
            var chain = new List<int>();
            var currentId = categoryId;

            // Traverse the category hierarchy upwards to get the parent chain
            while (currentId != null)
            {
                chain.Add(currentId.Value);
                currentId = GetParentCategoryId(currentId.Value); // Get parent category ID
            }

            return chain;
        }

        private int? GetParentCategoryId(int categoryId)
        {
            var parentCategory = _dbContext.Categories.FirstOrDefault(r=>r.Id == categoryId);
            return parentCategory.ParentCategoryId;
        }

        public int CategoryDepth(Category category)
        {
            if(category == null) return 0;

            return 1 + CategoryDepth(_dbContext.Categories.FirstOrDefault(r=> r.Id == category.ParentCategoryId)); 
        }

        public int FilmsInCategory(Category category)
        {
            return _dbContext.FilmCategories.Where(r => r.CategoryId == category.Id).ToList().Count;
        }
    }
}
