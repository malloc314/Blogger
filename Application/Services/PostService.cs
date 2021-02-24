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
        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(post => new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            });
        }

        // PL Implementacja metody GetPostById(id), zwraca post o podanym id i mapuje właściwości Post na PostDto.
        // EN Implementation the GetAllPosts(id) method, returns a post with the given id and maps Post properties to PostDto.
        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            return new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };
        }

        // PL Implementacja metody GetPostByTitle(title), zwraca posty zawierające podaną frazę w tytule i mapuje właściwości Post na PostDto.
        // EN Implementation the GetPostByTitle(title) method, returns posts containing the given phrase in the title and maps Post properties to PostDto.
        public async Task<IEnumerable<PostDto>> GetPostByTitleAsync(string title)
        {
            var posts = await _postRepository.GetAllAsync();

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

        // PL Implementacja metody AddNewPost(newPost), zwraca nowo dodanego posta i mapuje właściwości CreatePostDto do Post i Post do PostDto.
        // EN Implementing the AddNewPost(newPost) method, a newly added post, and maps CreatePostDto props to Post and Post to PostDto.
        public async Task<PostDto> AddNewPostAsync(CreatePostDto newPost)
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
                
                var result = await _postRepository.AddAsync(post);

                return new PostDto()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Content = result.Content
                };
            }
        }

        // PL Implementacja metody UpdatePost(updatePost), przypisuje wartości updatePost do existingPost.
        // EN Implementing the UpdatePost (updatePost) method, assigns the updatePost values ​​to existingPost.
        public async Task UpdatePostAsync(UpdatePostDto updatePost)
        {
            var existingPost = await _postRepository.GetByIdAsync(updatePost.Id);

            existingPost.Id = updatePost.Id;
            existingPost.Content = updatePost.Content;

            await _postRepository.UpdateAsync(existingPost);
        }

        // PL Implementacja metody DeletePost(id), usuwa posta o danym id.
        // EN Implementing the DeletePost(id) method, delete post with given id.
        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
