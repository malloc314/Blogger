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
        IEnumerable<PostDto> GetAllPosts();
        PostDto GetPostById(int id);
        IEnumerable<PostDto> GetPostByTitle(string title);
    }
}
