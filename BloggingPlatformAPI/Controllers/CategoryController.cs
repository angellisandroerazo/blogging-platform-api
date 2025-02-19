using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Data;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Interfaces;
using BloggingPlatformAPI.Dtos;

namespace BloggingPlatformAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService category)
        {
            _categoryService = category;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var result = await _categoryService.GetCategories();

            return Ok(result);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, CategoryPut category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var result = await _categoryService.PutCategory(id, category);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryPost category)
        {
           var result = await _categoryService.PostCategory(category);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteCategory(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

       
    }
}
