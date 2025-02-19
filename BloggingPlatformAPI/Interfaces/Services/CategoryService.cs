using BloggingPlatformAPI.Data;
using BloggingPlatformAPI.Dtos;
using BloggingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Interfaces.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BloggingDbContext _context;

        public CategoryService(BloggingDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategory(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> PutCategory(Guid id, CategoryPut newCategory)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            category.Name = newCategory.Name;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> PostCategory(CategoryPost category)
        {
            if(category.Name == null)
            {
                return null;
            }

            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = category.Name,
                CreatedAt = DateTime.Now,
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            
            return newCategory;
        }

        public async Task<Guid?> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return id;
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
