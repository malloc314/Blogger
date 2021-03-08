using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Posts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllCountAsync()
        {
            return await _context.Posts.CountAsync();
        }

        // PL Metoda GetById(id), jako argument przyjmuję id, zwraca post o podanym id.
        // EN The GetById(id) method, take id as an argument, returns a post with the given id.
        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        // PL Metoda Add(post), zwraca dodany post.
        // EN The Add(post) method, returns the added post.
        public async Task<Post> AddAsync(Post post)
        {
            post.Created = DateTime.UtcNow;
            
            var createdPost = await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return createdPost.Entity;
        }
        // PL Metoda Update(post), zwraca zaktualizowany post.
        // EN The Update(post) method, returns a updated post.
        public async Task UpdateAsync(Post post)
        {
            post.LastModified = DateTime.UtcNow;
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
        // PL Metoda Delete(post), zwraca usunięty post.
        // EN The Delete(post) method, returns a deleted post.
        public async Task DeleteAsync(Post post)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
