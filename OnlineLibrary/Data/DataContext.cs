using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineLibrary.Models;

namespace OnlineLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookSubscription> BookSubscriptions { get; set; }
    }
}