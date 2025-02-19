using System.Text.Json.Serialization;

namespace BloggingPlatformAPI.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public ICollection<PostTag> Posts { get; set; } = new List<PostTag>();
    }
}
