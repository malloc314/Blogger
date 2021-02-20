using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    // PL Implementacja interfejsu IPostRepository.
    // EN Implementation of the IPostRepository interface.
    public class PostRepository : IPostRepository
    {
        // PL Tworzenie listy postów w pamięci ?
        // EN Create a list of posts in memory ?
        private static readonly ISet<Post> _posts = new HashSet<Post>()
        {
            new Post(1, "Tytuł 1", "Treść 1"),
            new Post(2, "Tytuł 2", "Treść 2"),
            new Post(3, "Tytuł 3", "Treść 3")
        };

        // PL Metoda GetAll(), zwraca wszystkie posty.
        // EN The GetAll() method, returns all posts.
        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        // PL Metoda GetById(id), jako argument przyjmuję id, zwraca post o podanym id.
        // EN The GetById(id) method, take id as an argument, returns a post with the given id.
        public Post GetById(int id)
        {
            return _posts.SingleOrDefault(x => x.Id == id);
        }

        // PL Metoda Add(post), zwraca dodany post.
        // EN The Add(post) method, returns the added post.
        public Post Add(Post post)
        {
            post.Id = _posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _posts.Add(post);
            return post;
        }
        // PL Metoda Update(post), zwraca zaktualizowany post.
        // EN The Update(post) method, returns a updated post.
        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
        }
        // PL Metoda Delete(post), zwraca usunięty post.
        // EN The Delete(post) method, returns a deleted post.
        public void Delete(Post post)
        {
            _posts.Remove(post);
        }
    }
}
