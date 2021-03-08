using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    // PL Interfejs IPostService.
    // EN The IPostService interface.
    public interface IPostService
    {
        // PL Sygnatury metod z klasy PostService.
        // EN The signatures of methods from the PostService class.
        Task<IEnumerable<PostDto>> GetAllPostsAsync(int pageNumber, int pageSize);
        Task<int> GetAllPostsCountAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        //Task<IEnumerable<PostDto>> GetPostByTitleAsync(string title);
        Task<PostDto> AddNewPostAsync(CreatePostDto newPost);
        Task UpdatePostAsync(UpdatePostDto updatePost);
        Task DeletePostAsync(int id);

    }
}
