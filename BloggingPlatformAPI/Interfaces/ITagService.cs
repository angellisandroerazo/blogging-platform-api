using BloggingPlatformAPI.Dtos;
using BloggingPlatformAPI.Models;

namespace BloggingPlatformAPI.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetTags();
        Task<Tag?> GetTag(Guid id);
        Task<Tag?> PutTag(Guid id, TagPut Tag);
        Task<Tag?> PostTag(TagPost Tag);
        Task<Guid?> DeleteTag(Guid id);
    }
}
