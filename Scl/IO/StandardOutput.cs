using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.IO
{
    public class StandardOutput : IOutput
    {
        public void PrintLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
