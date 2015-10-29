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
        public string LastCalledWith { get; private set; }

        public void PrintLine(string output)
        {
            LastCalledWith = output;
        }
    }
}
