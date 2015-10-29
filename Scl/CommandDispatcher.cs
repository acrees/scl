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
            IPublishPost publish)
        {
            _getUser = userRetriever;
            _printPosts = print;
            _publish = publish;
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
        }

        private ICreateOrRetrieveUserByName _getUser;
        private IPrintPosts _printPosts;
        private IPublishPost _publish;
    }
}
