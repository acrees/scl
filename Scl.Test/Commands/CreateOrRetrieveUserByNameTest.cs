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
    public class CreateOrRetrieveUserByNameTest
    {
        [Fact]
        public void RetrievesUsersThatExist()
        {
            var spy = new UserRepositorySpy();
            var command = new CreateOrRetrieveUserByName(spy);

            var user = command.Execute("Alice");

            Assert.Null(spy.AddCalledWith);
            Assert.Equal("Alice", user.Name);
        }

        [Fact]
        public void CreatesAUserIfNotExisting()
        {
            var spy = new UserRepositorySpy();
            var command = new CreateOrRetrieveUserByName(spy);

            var user = command.Execute("Bob");

            Assert.Equal("Bob", spy.AddCalledWith.Name);
            Assert.Equal("Bob", user.Name);
        }
    }
}
