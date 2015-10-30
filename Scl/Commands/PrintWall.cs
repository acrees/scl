using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scl.IO;

namespace Scl.Commands
{
    public class PrintWall : IPrintWall
    {
        public PrintWall(IPostFormatter formatter, IOutput output)
        {
            _formatter = formatter;
            _output = output;
        }

        public void Execute(User user)
        {
            user.Following
                .SelectMany(u => u.Posts)
                .Select(_formatter.Print)
                .ToList()
                .ForEach(_output.PrintLine);
        }

        private IOutput _output;
        private IPostFormatter _formatter;
    }
}
