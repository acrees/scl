using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class PostFormatterSpy : IPostFormatter
    {
        public List<Post> CalledWith { get; set; }

        public PostFormatterSpy()
        {
            CalledWith = new List<Post>();
        }

        public string Print(Post post)
        {
            CalledWith.Add(post);
            return "Hello, World!";
        }
    }
}
