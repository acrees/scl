using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test
{
    public class UserTest
    {
       [Fact]
        public void PublishingAPostAllowsItToBeRead()
        {
            var user = new User("Alice");
            var post = new Post(user, "Hello, World!");

            user.Publish(post);

            Assert.Equal(new[] { post }, user.Posts);
        }
    }
}
