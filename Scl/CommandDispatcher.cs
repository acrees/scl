using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl
{
    public class CommandDispatcher
    {
        public CommandDispatcher(
            ICreateOrRetrieveUserByName userRetriever,
            IPrintPosts print,
            IPublishPost publish,
            IFollowUser follow)
        {
            _getUser = userRetriever;
            _printPosts = print;
            _publish = publish;
            _follow = follow;
        }

        public void Run(string[] input)
        {
            var user = _getUser.Execute(input[0]);
            if (input.Length == 1)
            {
                _printPosts.Execute(user);
            }
            else if (input[1] == "->")
            {
                var message = String.Join(" ", input.Skip(2));
                _publish.Execute(user, message);
            }
            else if (input[1] == "follows")
            {
                var userToFollow = _getUser.Execute(input[2]);
                _follow.Execute(user, userToFollow);
            }
        }

        private ICreateOrRetrieveUserByName _getUser;
        private IPrintPosts _printPosts;
        private IPublishPost _publish;
        private IFollowUser _follow;
    }
}
