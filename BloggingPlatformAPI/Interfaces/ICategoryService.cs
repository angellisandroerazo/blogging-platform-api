using BloggingPlatformAPI.Dtos;
using BloggingPlatformAPI.Models;

namespace BloggingPlatformAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category?> GetCategory(Guid id);
        Task<Category?> PutCategory(Guid id, CategoryPut category);
        Task<Category?> PostCategory(CategoryPost category);
        Task<Guid?> DeleteCategory(Guid id);
    }
}
