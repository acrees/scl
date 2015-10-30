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
    public class PrintPostsTest
    {
        [Fact]
        public void CallsThePrintFormatterForEachPost()
        {
            var user = new User("Alice");
            var posts = new List<Post>
            {
                new Post(user, "Hello!", DateTime.Now),
                new Post(user, "World!", DateTime.Now)
            };
            user.Publish(posts[0]);
            user.Publish(posts[1]);
            var spy = new PostFormatterSpy();
            var oSpy = new OutputSpy();
            var command = new PrintPosts(spy, oSpy);

            command.Execute(user);

            Assert.Equal(posts, spy.CalledWith);
        }

        [Fact]
        public void PrintsTheFormattedStrings()
        {
            var user = new User("Alice");
            user.Publish(new Post(user, "", DateTime.Now));
            var spy = new OutputSpy();
            var command = new PrintPosts(new PostFormatterDummy("Hello, World!"), spy);

            command.Execute(user);

            Assert.Equal(new[] { "Hello, World!" }, spy.CalledWith);
        }
    }
}
