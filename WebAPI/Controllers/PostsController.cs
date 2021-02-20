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
        // PL Przypisanie interfejsu IPostService do prywatnego pola _postService.
        // EN Assigning the IPostService interface to the private _postService field.
        private readonly IPostService _postService;

        // PL Przypisywanie implementacji interfejsu za pomocą konstruktora.
        // EN Assigning an interface implementation through a constructor.
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // PL Użycie Metody GetAllPosts() z interfesju IPostService z implementacją PostService. Punkt końctowy.
        // EN Using the GetAllPosts() method from the IPostService interface with the PostService implementation.
        // GET => api/Posts/id
        [HttpGet]
        public ActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        // PL Użycie Metody GetPostById(id) z interfesju IPostService z implementacją PostService.
        // EN Using the GetPostById(id) method from the IPostService interface with the PostService implementation.
        // GET => api/Posts/id
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
        // PL Użycie Metody GetPostByTitle(title) z interfesju IPostService z implementacją PostService.
        // EN Using the GetPostByTitle(title) method from the IPostService interface with the PostService implementation.
        // GET => api/Posts/Search/title.
        [HttpGet("Search/{title}")]
        public ActionResult Get(string title)
        {
            var posts = _postService.GetPostByTitle(title);
            return Ok(posts);
        }
    }
}
