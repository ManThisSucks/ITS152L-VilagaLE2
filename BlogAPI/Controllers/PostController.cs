using BlogDataLibrary.Data;
using BlogDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private ISqlData _db;

        public PostController(ISqlData db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ListPosts()
        {
            List<ListPostModel> posts = _db.ListPosts();

            return Ok(posts);
        }
    }
}
