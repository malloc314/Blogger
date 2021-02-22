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
    // PL Implementacja interfejsu IPostService.
    // EN Implementation of the IPostService interface.
    public class PostService : IPostService
    {
        // PL Przypisanie interfejsu IPostRepository do prywatnego pola _postRepository?
        // EN Assigning the IPostRepository interface to the _postRepository private field ?
        private readonly IPostRepository _postRepository;

        // PL Przypisywanie implementacji interfejsu za pomocą konstruktora.
        // EN Assigning an interface implementation through a constructor.
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // PL Implementacja metody GetAllPosts(), zwraca wszystkie posty i mapuje właściwości Post na PostDto.
        // EN Implementation the GetAllPosts () method, returns all posts, and maps Post properties to PostDto.
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

        // PL Implementacja metody GetPostById(id), zwraca post o podanym id i mapuje właściwości Post na PostDto.
        // EN Implementation the GetAllPosts(id) method, returns a post with the given id and maps Post properties to PostDto.
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

        // PL Implementacja metody GetPostByTitle(title), zwraca posty zawierające podaną frazę w tytule i mapuje właściwości Post na PostDto.
        // EN Implementation the GetPostByTitle(title) method, returns posts containing the given phrase in the title and maps Post properties to PostDto.
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

        // PL 
        // EN
        public PostDto AddNewPost(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Please enter title");
            }
            else
            {
                var post = new Post()
                {
                    Title = newPost.Title,
                    Content = newPost.Content
                };
                
                _postRepository.Add(post);

                return new PostDto()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content
                };
            }
        }

        // PL 
        // EN
        public void UpdatePost(UpdatePostDto updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);

            //var post = new Post
            //{
            //    existingPost.Id = updatePost.Id,
            //    existingPost.Content = updatePost.Content
            //};

            //_postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
    }
}
