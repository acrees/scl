using Scl.IO;
using Scl.Test.Doubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Scl.Test.IO
{
    public class PostFormatterTest
    {
        [Fact]
        public void PrintsPostsUsernameMessageAndTimeDifference()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddDays(1));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (1 day ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceTwoDays()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddDays(2));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (2 days ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceOneHour()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddHours(1));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (1 hour ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceTwoHours()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddHours(2));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (2 hours ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceOneMinute()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddMinutes(1));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (1 minute ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceTwoMinutes()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddMinutes(2));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (2 minutes ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceOneSecond()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddSeconds(1));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (1 second ago)", output);
        }

        [Fact]
        public void PrintsTimeDifferenceTwoSeconds()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!", DateTime.MinValue);

            var timeProvider = new CurrentTimeProviderDummy(DateTime.MinValue.AddSeconds(2));
            var formatter = new PostFormatter(timeProvider);

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World! (2 seconds ago)", output);
        }
    }
}
