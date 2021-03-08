using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Wrappers;

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
        public async Task<ActionResult> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
            var posts = await _postService.GetAllPostsAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize);
            var totalRecords = await _postService.GetAllPostsCountAsync();

            return Ok(PaginationHelper.CreatePagedResponse(posts, validPaginationFilter, totalRecords));
        }

        // PL Gdy przyjdzie żądanie http GET na adres "api/Posts/Search/id", zostanie uruchomiona metoda Get().
        // EN If a GET http request comes to the address "api/Posts/Search/id", the Get() method will be run.
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var posts = await _postService.GetPostByIdAsync(id);
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(new Response<PostDto>(posts));
        }

        // PL Gdy przyjdzie żądanie http GET na adres "api/Posts/Search/title", zostanie uruchomiona metoda Get().
        // EN If a GET http request comes to the address "api/Posts/Search/title", the Get() method will be run.
        //[HttpGet("Search/{title}")]
        //public async Task<ActionResult> Get(string title)
        //{
        //    var posts = await _postService.GetPostByTitleAsync(title);
        //    return Ok(new Response<IEnumerable<PostDto>>(posts));
        //}

        // PL Gdy przyjdzie żądanie http POST na adres "api/Posts", zostanie uruchomiona metoda Create(). 
        // EN If a POST http request comes to the address "api/Posts", the Create() method will be run.
        [HttpPost]
        public async Task<ActionResult> Create(CreatePostDto newPost)
        {
            var post = await _postService.AddNewPostAsync(newPost);
            return Created($"api/Posts/{post.Id}", new Response<PostDto>(post));
        }

        // PL Gdy przyjdzie żądanie http PUT na adres "api/Posts", zostanie uruchomiona metoda Update(). 
        // EN If a PUT http request comes to the address "api/Posts", the Update() method will be run.
        [HttpPut]
        public async Task<ActionResult> Update(UpdatePostDto updatePost)
        {
            await _postService.UpdatePostAsync(updatePost);
            return NoContent();
        }

        // PL Gdy przyjdzie żądanie http DELETE na adres "api/Posts/id", zostanie uruchomiona metoda Remove(). 
        // EN If a DELETE http request comes to the address "api/Posts/id", the Remove() method will be run.
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
