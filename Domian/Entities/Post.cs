using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{   
    // Domenowy model posta.
    // Domain post model.
    public class Post : AuditableEntity
    {
        // Zmiana test git.
        // Iniciacja właściowości klasy Post.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // Konstrukor bezparametrowy Post.
        public Post() { }

        // Konstruktor parametrowy Post.               xD
        public Post(int id, string title, string content)
        {
            (Id, Title, Content) = (id, title, content);    
        }
    }
}
