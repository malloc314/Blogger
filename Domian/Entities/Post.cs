using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // PL Domenowy model posta dziedziczący po klasie AuditableEntity.
    // EN Domain post model inheriting from the AuditableEntity class.
    public class Post : AuditableEntity
    {
        // PL Iniciacja właściowości klasy Post.
        // EN Proper initiation of the Post class.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // PL Konstrukor bezparametrowy Post.
        // EN Parameterless constructor Post.
        public Post() { }

        // PL Konstruktor Post z argumentami id, title, content.
        // EN Post constructor with arguments id, title, content.
        public Post(int id, string title, string content)
        {
            (Id, Title, Content) = (id, title, content);    
        }
    }
}
