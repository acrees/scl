using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Commands
{
    public class PublishPost : IPublishPost
    {
        public void Execute(User user, string message)
        {
            var post = new Post(user, message);
            user.Publish(post);
        }
    }
}
