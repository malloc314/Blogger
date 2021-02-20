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
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Add(Post post);
        void Update(Post post);
        void Delete(Post post);
    }
}
