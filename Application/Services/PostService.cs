using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return posts.Select(post => new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            });
        }

        public PostDto GetPostById(int id)
        {
            var post = _postRepository.GetById(id);

            return new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };
        }

        public IEnumerable<PostDto> GetPostByTitle(string title)
        {
            var posts = _postRepository.GetAll();

            if (string.IsNullOrWhiteSpace(title))
            {
                return posts.Select(post => new PostDto()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content
                });
            }

            var searched = new List<PostDto>();

            foreach (var post in posts)
            {
                if (post.Title.ToLower().Contains(title.ToLower()))
                {
                    searched.Add(new PostDto()
                        {
                            Id = post.Id,
                            Title = post.Title,
                            Content = post.Content
                        });
                }
            }
            return searched.AsEnumerable();
        }
    }
}
