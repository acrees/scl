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
        public PublishPost(ICurrentTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public void Execute(User user, string message)
        {
            var post = new Post(user, message, _timeProvider.CurrentTime());
            user.Publish(post);
        }

        private ICurrentTimeProvider _timeProvider;
    }
}
