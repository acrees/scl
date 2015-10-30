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
        public DateTime Timestamp { get; private set; }

        public Post(User user, string message, DateTime timestamp)
        {
            User = user;
            Message = message;
            Timestamp = timestamp;
        }

        public override bool Equals(object obj)
        {
            var otherPost = obj as Post;
            if (otherPost == null) return base.Equals(obj);
            return Message == otherPost.Message
                && User == otherPost.User
                && Timestamp == otherPost.Timestamp;
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = (hash * 7) + Message.GetHashCode();
            hash = (hash * 7) + User.GetHashCode();
            hash = (hash * 7) + Timestamp.GetHashCode();
            return hash;
        }
    }
}
