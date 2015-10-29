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
        public CommandDispatcher(ICreateOrRetrieveUserByName userRetriever,
            IPrintPosts print)
        {
            _getUser = userRetriever;
            _printPosts = print;
        }

        public void Run(string[] input)
        {
            var user = _getUser.Execute(input[0]);
            _printPosts.Execute(user);
        }

        private ICreateOrRetrieveUserByName _getUser;
        private IPrintPosts _printPosts;
    }
}
