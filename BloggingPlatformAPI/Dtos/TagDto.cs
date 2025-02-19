using System.ComponentModel.DataAnnotations;

namespace BloggingPlatformAPI.Dtos
{
    public class TagPut
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }

    public class TagPost
    {
        [Required]
        public required string Name { get; set; }
    }
}
