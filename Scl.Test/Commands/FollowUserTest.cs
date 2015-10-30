using Scl.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test.Commands
{
    public class FollowUserTest
    {
        [Fact]
        public void AddsUserToFollowingList()
        {
            var alice = new User("Alice");
            var bob = new User("Bob");
            var command = new FollowUser();

            command.Execute(alice, bob);

            Assert.Equal(new[] { bob }, alice.Following);
        }
    }
}
