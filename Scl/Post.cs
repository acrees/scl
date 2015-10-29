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

        public override bool Equals(object obj)
        {
            var otherPost = obj as Post;
            if (otherPost == null) return base.Equals(obj);
            return otherPost.Message == Message;
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + Message.GetHashCode();
            return hash;
        }
    }
}
