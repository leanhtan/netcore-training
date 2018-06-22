using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBlogEngine.Repository.Models;
using System.IO;

namespace SimpleBlogEngine.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
