using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BloggingPlatformAPI.Dtos
{
    public class CategoryPut
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }

    public class CategoryPost
    {
        [Required]
        public required string Name { get; set; }
    }
}
