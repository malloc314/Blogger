using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // PL Interfejs IPostRepository.
    // En The IPostRepository interface.
    public interface IPostRepository
    {
        // PL Sygnatury metod z klasy PostRepository.
        // EN The signatures of methods from the PostRepository class.
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
}
