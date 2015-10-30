using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Commands
{
    public class PrintPosts : IPrintPosts
    {
        public PrintPosts(IPostFormatter formatter, IOutput output)
        {
            _formatter = formatter;
            _output = output;
        }

        public void Execute(User user)
        {
            user.Posts.OrderByDescending(p => p.Timestamp)
                      .Select(_formatter.Print)
                      .ToList()
                      .ForEach(_output.PrintLine);
        }

        private IPostFormatter _formatter;
        private IOutput _output;
    }
}
