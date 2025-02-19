using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformAPI.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public required Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public ICollection<PostTag> Tags { get; set; } = new List<PostTag>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
