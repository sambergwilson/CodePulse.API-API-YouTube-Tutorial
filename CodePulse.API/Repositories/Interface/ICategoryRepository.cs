using CodePulse.API.Models.Domian;

namespace CodePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Guid Id, Category category);
        Task<Category> DeleteAsync(Category category);
        Task<Category> GetByIdAsync(Guid id);
        Task<List<Category>> GetAllAsync(Category categories);
    }
}
