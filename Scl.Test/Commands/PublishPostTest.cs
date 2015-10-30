using Scl.Commands;
using Scl.Test.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test.Commands
{
    public class PublishPostTest
    {
        [Fact]
        public void CreatesAPostWithTheMessage()
        {
            var time = DateTime.Now;
            var timeProvider = new CurrentTimeProviderDummy(time);

            var user = new User("Alice");
            var command = new PublishPost(timeProvider);

            command.Execute(user, "Hello, World!");

            Assert.Equal(new[] { new Post(user, "Hello, World!", time) }, user.Posts);
        }
    }
}
