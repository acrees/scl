using Scl.Commands;
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
            var user = new User("Alice");
            var command = new PublishPost();

            command.Execute(user, "Hello, World!");

            Assert.Equal(new[] { new Post("Hello, World!") }, user.Posts);
        }
    }
}
