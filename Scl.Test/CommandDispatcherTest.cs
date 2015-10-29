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
            var dispatcher = new CommandDispatcher(retriever, spy);
            dispatcher.Run(new[] { "Alice" });

            Assert.Equal(alice, spy.LastCalledWith);
        }
    }
}
