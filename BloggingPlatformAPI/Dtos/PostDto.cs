using BloggingPlatformAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloggingPlatformAPI.Dtos
{
    public class PostPut
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public required Guid CategoryId { get; set; }

        public List<Guid> Tags { get; set; } = new List<Guid>();
    }

    public class PostPost
    {

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public required Guid CategoryId { get; set; }

        public List<Guid> Tags { get; set; } = new List<Guid>();
    }

    public class PostGet
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public required string Category { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
