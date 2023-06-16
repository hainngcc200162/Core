using bloghub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace bloghub.Context
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
