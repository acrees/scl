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
            IFollowUser follow,
            IPrintWall wall)
        {
            _getUser = userRetriever;
            _printPosts = print;
            _publish = publish;
            _follow = follow;
            _wall = wall;
        }

        public void Run(string[] input)
        {
            var user = _getUser.Execute(input[0]);
            if (IsPrintPostsCommand(input))
            {
                _printPosts.Execute(user);
            }
            else if (IsPublishCommand(input))
            {
                var message = String.Join(" ", input.Skip(2));
                _publish.Execute(user, message);
            }
            else if (IsFollowCommand(input))
            {
                var userToFollow = _getUser.Execute(input[2]);
                _follow.Execute(user, userToFollow);
            }
            else if (IsPrintWallCommand(input))
            {
                _wall.Execute(user);
            }
        }

        private bool IsPrintPostsCommand(string[] input)
        {
            return input.Length == 1;
        }

        private bool IsPublishCommand(string[] input)
        {
            return input[1] == "->";
        }

        private bool IsFollowCommand(string[] input)
        {
            return input[1] == "follows";
        }

        private bool IsPrintWallCommand(string[] input)
        {
            return input[1] == "wall";
        }

        private ICreateOrRetrieveUserByName _getUser;
        private IPrintPosts _printPosts;
        private IPublishPost _publish;
        private IFollowUser _follow;
        private IPrintWall _wall;
    }
}
