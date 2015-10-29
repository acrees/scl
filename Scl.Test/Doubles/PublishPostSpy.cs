using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class PublishPostSpy : IPublishPost
    {
        public string MessageCalledWith { get; private set; }
        public User UserCalledWith { get; private set; }

        public void Execute(User user, string message)
        {
            UserCalledWith = user;
            MessageCalledWith = message;
        }
    }
}
