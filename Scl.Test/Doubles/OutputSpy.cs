using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class OutputSpy : IOutput
    {
        public List<string> CalledWith { get; private set; }

        public OutputSpy()
        {
            CalledWith = new List<string>();
        }

        public void PrintLine(string output)
        {
            CalledWith.Add(output);
        }
    }
}
