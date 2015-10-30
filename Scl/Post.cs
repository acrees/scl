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
        public User User { get; private set; }

        public Post(User user, string message)
        {
            User = user;
            Message = message;
        }

        public override bool Equals(object obj)
        {
            var otherPost = obj as Post;
            if (otherPost == null) return base.Equals(obj);
            return otherPost.Message == Message
                && User == otherPost.User;
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + Message.GetHashCode();
            hash = (hash * 7) + User.GetHashCode();
            return hash;
        }
    }
}
