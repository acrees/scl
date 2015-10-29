using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl
{
    public class User
    {
        public string Name { get; private set; }

        public IEnumerable<Post> Posts
        {
            get { return _posts.AsEnumerable(); }
        }

        public User(string name)
        {
            Name = name;
        }

        public void Publish(Post newPost)
        {
            _posts.Add(newPost);
        }

        private List<Post> _posts = new List<Post>();
    }
}
