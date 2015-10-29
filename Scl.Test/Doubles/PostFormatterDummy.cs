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
        public PostFormatterDummy(string output)
        {
            _output = output;
        }

        public string Print(Post post)
        {
            return _output;
        }

        private string _output;
    }
}
