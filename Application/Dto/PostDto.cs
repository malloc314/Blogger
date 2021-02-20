using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    // PL Klasa PostDto warunkuje co zostanie zwrócone do WebAPI.
    // EN The PostDto class determines what will be returned to the WebAPI.
    public class PostDto
    {
        // PL Deklaracja właściwości.
        // EN Property declaration.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
