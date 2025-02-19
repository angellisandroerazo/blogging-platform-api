using System.Text.Json.Serialization;

namespace BloggingPlatformAPI.Models
{
    public class PostTag
    {
        public Guid PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }

        public Guid TagId { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }
    }
}
