using bloghub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace bloghub.Repository
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAll();
        Task<BlogPost> GetById(int id);
        Task<IActionResult> AddBlog(BlogPost blogPost);

        Task<bool> UpdateBlog(BlogPost blogPost);
        Task<bool> DeleteBlog(int id);
    }
}
