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
        public void CallsThePrintFormatter()
        {
            var user = new User("Alice");
            var post = new Post(user, "Hello!", DateTime.Now);
            user.Publish(post);
            var spy = new PostFormatterSpy();
            var oSpy = new OutputSpy();
            var command = new PrintPosts(spy, oSpy);

            command.Execute(user);

            Assert.Equal(new[] { post }, spy.CalledWith);
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

        [Fact]
        public void PrintsInDescendingTimestampOrder()
        {
            var user = new User("Alice");
            var posts = new[]
            {
                new Post(user, "Hello, world!", DateTime.MinValue),
                new Post(user, "Bonjour la monde!", DateTime.MinValue.AddYears(1)),
                new Post(user, "Sekai, konnichiwa!", DateTime.MinValue.AddYears(2))
            };
            user.Publish(posts[0]);
            user.Publish(posts[1]);
            user.Publish(posts[2]);

            var spy = new OutputSpy();
            var command = new PrintPosts(new PostFormatterDummy(p => p.Message), spy);

            command.Execute(user);

            Assert.Equal(
                new[] { "Sekai, konnichiwa!", "Bonjour la monde!", "Hello, world!" },
                spy.CalledWith);
        }
    }
}
