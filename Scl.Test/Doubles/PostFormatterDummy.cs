using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class PostFormatterDummy : IPostFormatter
    {
        public PostFormatterDummy(string s) :this(_=>s) { }
        public PostFormatterDummy(Func<Post, string> format)
        {
            _format = format;
        }

        public string Print(Post post)
        {
            return _format(post);
        }

        private Func<Post, string> _format;
    }
}
