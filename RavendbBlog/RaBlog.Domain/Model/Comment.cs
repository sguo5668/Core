using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaBlog.Domain.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
    }
}
