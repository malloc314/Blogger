using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
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
        // PL Przypisanie do prywatnego pola klasy BloggerContext.
        // EN Assignment to a private field of the BloggerContext class.
        private readonly BloggerContext _context;

        public PostRepository(BloggerContext context)
        {
            _context = context;
        }

        // PL Metoda GetAll(), zwraca wszystkie posty.
        // EN The GetAll() method, returns all posts.
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts;
        }

        // PL Metoda GetById(id), jako argument przyjmuję id, zwraca post o podanym id.
        // EN The GetById(id) method, take id as an argument, returns a post with the given id.
        public Post GetById(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }

        // PL Metoda Add(post), zwraca dodany post.
        // EN The Add(post) method, returns the added post.
        public Post Add(Post post)
        {
            //post.Id = _posts.Count() + 1;
            post.Created = DateTime.UtcNow;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }
        // PL Metoda Update(post), zwraca zaktualizowany post.
        // EN The Update(post) method, returns a updated post.
        public void Update(Post post)
        {
            post.LastModified = DateTime.UtcNow;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
        // PL Metoda Delete(post), zwraca usunięty post.
        // EN The Delete(post) method, returns a deleted post.
        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
