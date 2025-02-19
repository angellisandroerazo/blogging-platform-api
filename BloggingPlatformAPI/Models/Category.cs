﻿namespace BloggingPlatformAPI.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
