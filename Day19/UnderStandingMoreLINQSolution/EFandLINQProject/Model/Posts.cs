using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Model
{
    public class Posts
    {
        public int Id { get; set; }
        public string PostText { get; set; }
        public string Category { get; set; }
        public ICollection<Comments> comments { get; set; }
    }
}
