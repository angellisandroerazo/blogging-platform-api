using BloggingPlatformAPI.Dtos;
using BloggingPlatformAPI.Models;

namespace BloggingPlatformAPI.Interfaces
{
    public interface IPostService
    {
       Task<IEnumerable<PostGet>> GetPosts();
       Task<PostGet?> GetPost(Guid id);
       Task<PostGet?> PostPost(PostPost post);
       Task<PostGet?> PutPost(Guid id, PostPut post);
       Task<Guid?> DeletePost(Guid id);
    }
}
