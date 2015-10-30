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
            var post = new Post("Hello, World!");

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
            var post = new Post("Hello, World!");

            alice.Follow(bob);
            bob.Publish(post);

            var outputSpy = new OutputSpy();
            var postFormatter = new PostFormatterDummy("Hello!");

            var command = new PrintWall(postFormatter, outputSpy);
            command.Execute(alice);

            Assert.Equal(new[] { "Hello!" }, outputSpy.CalledWith);
        }
    }
}
