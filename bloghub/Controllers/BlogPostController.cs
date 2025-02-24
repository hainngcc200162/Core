using bloghub.Models;
using bloghub.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace bloghub.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        IBlogPostRepository _blogPostRepository;
        public BlogPostController(IBlogPostRepository blogPostRepository) 
        { 
            _blogPostRepository = blogPostRepository;
        }

        [ProducesResponseType(typeof(List<BlogPost>),(int) HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _blogPostRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(BlogPost), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var blogPost = await _blogPostRepository.GetById(id);
                if(blogPost == null)
                {
                    return NotFound();
                }
                return Ok(blogPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody] BlogPost blogPost)
        {
            // Gọi phương thức trong service để xử lý logic
            return await _blogPostRepository.AddBlog(blogPost);
        }


        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogPost blogPost)
        {
            try
            {
                bool isUpdated = await _blogPostRepository.UpdateBlog(blogPost);
                if (isUpdated)
                {
                    return Ok("Blog has been modified.");
                }
                return BadRequest("Blog modified failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                bool isDeleted = await _blogPostRepository.DeleteBlog(id);
                if (isDeleted)
                {
                    return Ok("Blog has been deleted.");
                }
                return BadRequest("Blog deleted failed.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
