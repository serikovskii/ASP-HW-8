using System;

namespace WebApplication14.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Login { get; set; }
        public string Password { get; set; }
    }
}