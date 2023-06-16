using bloghub.Context;
using bloghub.Models;
using Microsoft.EntityFrameworkCore;

namespace bloghub.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        BlogDbContext _dbContext;
        public BlogPostRepository(BlogDbContext doContext)
        {
            _dbContext = doContext;
        }

        public async Task<bool> AddBlog(BlogPost blogPost)
        {
            FormattableString query = $"INSERT INTO BlogPosts (Title,Content,PublishedOn) VALUES({blogPost.Title},{blogPost.Content},{blogPost.PublishedOn})";
            int rowAffected = await _dbContext.Database.ExecuteSqlAsync(query);
            return rowAffected > 0;
        }

        public async Task<bool> DeleteBlog(int id)
        {
            FormattableString query = $"DELETE FROM BlogPosts WHERE Id={id}";
            int rowAffected = await _dbContext.Database.ExecuteSqlAsync(query);
            return rowAffected > 0;
        }

        public  async Task<List<BlogPost>> GetAll()
        {
            FormattableString query = $"SELECT * FROM BlogPosts";
            return await _dbContext.Database.SqlQuery<BlogPost>(query).ToListAsync();         
            
        }

        public async Task<BlogPost> GetById(int id)
        {
            FormattableString query = $"SELECT * FROM BlogPosts WHERE Id={id}";
            return await _dbContext.Database.SqlQuery<BlogPost>(query).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateBlog(BlogPost blogPost)
        {
            FormattableString query=$"UPDATE BlogPosts SET Title={blogPost.Title},Content={blogPost.Content},PublishedOn={blogPost.PublishedOn} WHERE Id={blogPost.Id}";
            int rowAffected=await _dbContext.Database.ExecuteSqlAsync(query);
            return rowAffected > 0;
        }
    }
}
