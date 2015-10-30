﻿using Scl.IO;
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
        public void PrintsPostsUsernameAndMessage()
        {
            var alice = new User("Alice");
            var post = new Post(alice, "Hello, World!");
            var formatter = new PostFormatter();

            var output = formatter.Print(post);

            Assert.Equal("Alice - Hello, World!", output);
        }
    }
}
