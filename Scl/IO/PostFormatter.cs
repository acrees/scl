using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.IO
{
    public class PostFormatter : IPostFormatter
    {
        public string Print(Post post)
        {
            return post.Message;
        }
    }
}
