using Scl.Test.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test
{
    public class CommandDispatcherTest
    {
        [Fact]
        public void UsernameOnlyPrintsThatUsersPosts()
        {
            var alice = new User("Alice");
            var retriever = new StubUserRetriever(alice);

            var spy = new PrintPostsSpy();
            var pSpy = new PublishPostSpy();
            var dispatcher = new CommandDispatcher(retriever, spy, pSpy);
            dispatcher.Run(new[] { "Alice" });

            Assert.Equal(alice, spy.LastCalledWith);
        }

        [Fact]
        public void UsernameArrowMessagePublishesMessage()
        {
            var alice = new User("Alice");
            var retriever = new StubUserRetriever(alice);

            var spy = new PrintPostsSpy();
            var pSpy = new PublishPostSpy();
            var dispatcher = new CommandDispatcher(retriever, spy, pSpy);
            dispatcher.Run(new[] { "Alice", "->", "Hello,", "World!" });

            Assert.Equal(alice, pSpy.UserCalledWith);
            Assert.Equal("Hello, World!", pSpy.MessageCalledWith);
        }
    }
}
