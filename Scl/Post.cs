using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl
{
    public class Post
    {
        public string Message { get; private set; }

        public Post(string message)
        {
            Message = message;
        }
    }
}
