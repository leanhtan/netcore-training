using Microsoft.EntityFrameworkCore;
using SimpleBlogEngine.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogEngine.Repository
{
    public class ApplicaitonContext : DbContext
    {
        public ApplicaitonContext(DbContextOptions<ApplicaitonContext> options) : base(options)
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
