using CodePulse.API.Data;
using CodePulse.API.Models.Domian;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CodePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Guid Id, Category category)
        {
            var existingCategory = _context.Categories.Find(Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.UrlHandle = category.UrlHandle;

                await _context.SaveChangesAsync();
            }

            return category;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            category = _context.Categories.Find(category.Id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            List<Category> result = _context.Categories.ToList();

            return result;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = _context.Categories.Find(id);

            return category;
        }
    }
}
