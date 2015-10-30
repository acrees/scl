using Scl.Commands;
using Scl.IO;
using Scl.Test.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test.Commands
{
    public class PrintWallTest
    {
        [Fact]
        public void FormatsPosts()
        {
            var alice = new User("Alice");
            var bob = new User("Bob");
            var post = new Post(bob, "Hello, World!", DateTime.Now);

            alice.Follow(bob);
            bob.Publish(post);

            var outputSpy = new OutputSpy();
            var postFormatter = new PostFormatterSpy();

            var command = new PrintWall(postFormatter, outputSpy);
            command.Execute(alice);

            Assert.Equal(new[] { post }, postFormatter.CalledWith);
        }

        [Fact]
        public void OutputsFormattedStrings()
        {
            var alice = new User("Alice");
            var bob = new User("Bob");
            var post = new Post(bob, "Hello, World!", DateTime.Now);

            alice.Follow(bob);
            bob.Publish(post);

            var outputSpy = new OutputSpy();
            var postFormatter = new PostFormatterDummy("Hello!");

            var command = new PrintWall(postFormatter, outputSpy);
            command.Execute(alice);

            Assert.Equal(new[] { "Hello!" }, outputSpy.CalledWith);
        }

        [Fact]
        public void OutputsPostsInDescendingTimestampOrder()
        {
            var alice = new User("Alice");
            var bob = new User("Bob");
            var charlie = new User("Charlie");

            alice.Follow(bob);
            alice.Follow(charlie);

            var posts = new[]
            {
                new Post(bob, "Hello, world!", DateTime.MinValue),
                new Post(charlie, "Bonjour la monde!", DateTime.MinValue.AddYears(1)),
                new Post(bob, "Sekai, konnichiwa!", DateTime.MinValue.AddYears(2))
            };

            bob.Publish(posts[0]);
            bob.Publish(posts[2]);
            charlie.Publish(posts[1]);

            var outputSpy = new OutputSpy();
            var postFormatter = new PostFormatterDummy(p => p.Message);
            var command = new PrintWall(postFormatter, outputSpy);
            command.Execute(alice);

            Assert.Equal(
                new[] { "Sekai, konnichiwa!", "Bonjour la monde!", "Hello, world!" },
                outputSpy.CalledWith);
        }
    }
}
