using Application.Dto;
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

        // PL Gdy przyjdzie żądanie http GET na adres "api/Posts", zostanie uruchomiona metoda Get().
        // EN If a GET http request comes to the address "api/Posts", the Get() method will be run.
        [HttpGet]
        public ActionResult Get()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        // PL Gdy przyjdzie żądanie http GET na adres "api/Posts/Search/id", zostanie uruchomiona metoda Get().
        // EN If a GET http request comes to the address "api/Posts/Search/id", the Get() method will be run.
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

        // PL Gdy przyjdzie żądanie http GET na adres "api/Posts/Search/title", zostanie uruchomiona metoda Get().
        // EN If a GET http request comes to the address "api/Posts/Search/title", the Get() method will be run.
        [HttpGet("Search/{title}")]
        public ActionResult Get(string title)
        {
            var posts = _postService.GetPostByTitle(title);
            return Ok(posts);
        }

        // PL Gdy przyjdzie żądanie http POST na adres "api/Posts", zostanie uruchomiona metoda Create(). 
        // EN If a POST http request comes to the address "api/Posts", the Create() method will be run.
        [HttpPost]
        public ActionResult Create(CreatePostDto newPost)
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/Posts/{post.Id}", post);
        }
    }
}
