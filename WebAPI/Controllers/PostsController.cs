using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var posts = _postService.GetPostById(id);
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        [HttpGet("Search/{title}")]
        public ActionResult Get(string title)
        {
            var posts = _postService.GetPostByTitle(title);
            return Ok(posts);
        }
    }
}
