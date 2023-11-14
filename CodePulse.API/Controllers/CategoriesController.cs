using CodePulse.API.Data;
using CodePulse.API.Models.Domian;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    // To reach the end point to this controller
    // https://localhost:xxxx/api/categories
    [Route("api/[controller]")] // <<<< Base Route to the Controller itself
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // 
        [HttpPost] // << Attribute
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            // Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            
            var result = await _categoryRepository.CreateAsync(category);

            // Map from Domain Model to a DTO
            var response = new CategoryDto
            {
                Id = result.Id,
                Name = result.Name,
                UrlHandle = result.UrlHandle
            };

            return Ok(response);
        }

        [HttpDelete("{Id}")] // << Attribute
        public async Task<IActionResult> DeleteCategory(Guid Id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(Id);

            await _categoryRepository.DeleteAsync(existingCategory);

            return NoContent();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            var category = await _categoryRepository.GetByIdAsync(Id);

            return Ok(category);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCategoryById(Guid Id, [FromBody]UpdateCategoryRequestDto request)
        {
            var category = new Category
            {
                Id = Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            var result = await _categoryRepository.UpdateAsync(Id, category);

            var response = new UpdateCategoryRequestDto
            {
                Name = result.Name,
                UrlHandle = result.UrlHandle
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryRepository.GetAllAsync();

            return Ok(result);
        }
    }
}
