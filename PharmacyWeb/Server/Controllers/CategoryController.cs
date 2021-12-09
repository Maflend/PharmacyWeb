using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyWeb.Server.Services.CategoryService;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            if (categories != null)
                return Ok(categories);
            else
                return BadRequest(categories.Message = "Категории не найдены");
        }
    }
}
