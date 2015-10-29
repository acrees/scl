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
            var posts = new List<Post> { new Post("Hello!"), new Post("World!") };
            var user = new User("Alice");
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
            user.Publish(new Post(""));
            var spy = new OutputSpy();
            var command = new PrintPosts(new PostFormatterDummy("Hello, World!"), spy);

            command.Execute(user);

            Assert.Equal("Hello, World!", spy.LastCalledWith);
        }
    }
}
