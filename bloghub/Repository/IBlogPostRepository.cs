using bloghub.Models;

namespace bloghub.Repository
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAll();
        Task<BlogPost> GetById(int id);
        Task<bool> AddBlog(BlogPost blogPost);
        Task<bool> UpdateBlog(BlogPost blogPost);
        Task<bool> DeleteBlog(int id);
    }
}
