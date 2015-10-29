using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class StubUserRetriever : ICreateOrRetrieveUserByName
    {
        public StubUserRetriever(User user)
        {
            _user = user;
        }

        public User Execute(string name)
        {
            return _user;
        }

        private User _user;
    }
}
