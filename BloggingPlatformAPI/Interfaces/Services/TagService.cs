using BloggingPlatformAPI.Dtos;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Interfaces.Services
{
    public class TagService : ITagService
    {

        private readonly BloggingDbContext _context;

        public TagService(BloggingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag?> GetTag(Guid id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag?> PutTag(Guid id, TagPut newTag)
        {
            var tag = await _context.Tags.FindAsync(id);

            if (tag == null)
            {
                return null;
            }

            tag.Name = newTag.Name;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag?> PostTag(TagPost tag)
        {
            if (tag.Name == null)
            {
                return null;
            }

            var newTag = new Tag
            {
                Id = Guid.NewGuid(),
                Name = tag.Name,
                CreatedAt = DateTime.Now,
            };

            _context.Tags.Add(newTag);
            await _context.SaveChangesAsync();

            return newTag;
        }

        public async Task<Guid?> DeleteTag(Guid id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return id;
        }

        private bool TagExists(Guid id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }

    }
}
