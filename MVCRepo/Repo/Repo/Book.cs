using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo
{
    public class Book : BaseEntity
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public virtual Author Author { get; set; }
    }
}
