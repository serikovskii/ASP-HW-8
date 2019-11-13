using System;

namespace WebApplication14.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Path { get; set; }
        public string UserId { get; set; }
    }
}