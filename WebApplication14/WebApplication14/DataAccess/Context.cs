namespace WebApplication14.DataAccess
{
    using System.Data.Entity;
    using WebApplication14.Models;

    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        
    }

}