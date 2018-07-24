using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaBlog.Domain.Model
{
    public class Blog
    {
        public Blog()
        {
           
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
