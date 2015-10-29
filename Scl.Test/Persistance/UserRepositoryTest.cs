using Scl.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test
{
    public class UserRepositoryTest
    {
        [Fact]
        public void DoesNotRetrieveUserThatDoesNotExist()
        {
            var repo = new UserRepository();
            Assert.Null(repo.Get("Alice"));
        }

        [Fact]
        public void RetrievesUserByName()
        {
            var repo = new UserRepository();
            var alice = new User("Alice");
            repo.Add(alice);

            Assert.Equal(alice, repo.Get("Alice"));
        }
    }
}
