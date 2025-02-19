using BloggingPlatformAPI.Data;
using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Dtos;
using System.Linq;

namespace BloggingPlatformAPI.Interfaces.Services
{
    public class PostService : IPostService
    {
        private readonly BloggingDbContext _context;
        public PostService(BloggingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostGet>> GetPosts()
        {
            var post = await _context.Posts.Include(i => i.Tags).ThenInclude(ti => ti.Tag).Include(i => i.Category).ToListAsync();

            var result = post.Select(p => new PostGet
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Category = p.Category.Name,
                Tags = p.Tags.Select(t => new Tag
                {
                    Id = t.Tag.Id,
                    Name = t.Tag.Name,
                    CreatedAt = t.Tag.CreatedAt,
                }).ToList(),
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
            }
                );


            return result;
        }

        public async Task<PostGet?> GetPost(Guid id)
        {
            var post = await _context.Posts.Include(i => i.Tags).ThenInclude(ti => ti.Tag).Include(i => i.Category).FirstOrDefaultAsync(f => f.Id == id);

            if (post == null)
            {
                return null;
            }

            var result = new PostGet
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Category = post.Category.Name,
                Tags = post.Tags.Select(t => new Tag
                {
                    Id = t.Tag.Id,
                    Name = t.Tag.Name,
                    CreatedAt = t.Tag.CreatedAt,
                }).ToList(),
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
            };


            return result;
        }

        public async Task<PostGet?> PutPost(Guid id, PostPut newPost)
        {
            var post = await _context.Posts.Include(i => i.Tags).FirstOrDefaultAsync(i => i.Id == id);

            if (post == null)
            {
                return null;
            }

            var tags = await _context.Tags.Where(t => newPost.Tags.Contains(t.Id)).ToListAsync();

            if (tags.Count != post.Tags.Count)
            {
                return null;
            }

            post.Title = newPost.Title;
            post.Content = newPost.Content;
            post.CategoryId = newPost.CategoryId;
            post.Tags = tags.Select(t => new PostTag { PostId = id, TagId = t.Id }).ToList(); 
            post.UpdatedAt = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            var editedPost = await _context.Posts.Include(i => i.Tags).ThenInclude(ti=> ti.Tag).Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
            if (editedPost == null)
            {
                return null;
            }

            var result = new PostGet
            {
                Id = editedPost.Id,
                Title = editedPost.Title,
                Content = editedPost.Content,
                Category = editedPost.Category.Name,
                Tags = editedPost.Tags.Select(t => new Tag
                {
                    Id = t.Tag.Id,
                    Name = t.Tag.Name,
                    CreatedAt = t.Tag.CreatedAt,
                }).ToList(),
            };

            return result;
        }

        public async Task<PostGet?> PostPost(PostPost post)
        {
            var id = Guid.NewGuid();


            var tags = await _context.Tags.Where(t => post.Tags.Contains(t.Id)).ToListAsync();

            if (tags.Count != post.Tags.Count)
            {
                return null;
            }


            var newPost = new Post
            {
                Id = id,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Tags = tags.Select(t => new PostTag { PostId = id, TagId = t.Id }).ToList()
            };

            _context.Posts.Add(newPost);

            await _context.SaveChangesAsync();


            var createdPost = await _context.Posts.Include(i => i.Tags).ThenInclude(ti => ti.Tag).Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
            if(createdPost == null)
            {
                return null;
            }

            var result = new PostGet
            {
                Id = createdPost.Id,
                Title = createdPost.Title,
                Content = createdPost.Content,
                Category = createdPost.Category.Name,
                Tags = createdPost.Tags.Select(t => new Tag
                {
                    Id = t.Tag.Id,
                    Name = t.Tag.Name,
                    CreatedAt = t.Tag.CreatedAt,
                }).ToList(),
                CreatedAt = createdPost.CreatedAt,
                UpdatedAt = createdPost.UpdatedAt,
            };

            return result;
        }

        public async Task<Guid?> DeletePost(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return id;
        }

        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
