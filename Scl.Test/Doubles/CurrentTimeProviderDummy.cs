using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class CurrentTimeProviderDummy : ICurrentTimeProvider
    {
        public CurrentTimeProviderDummy(DateTime output)
        {
            _output = output;
        }

        public DateTime CurrentTime()
        {
            return _output;
        }

        private DateTime _output;
    }
}
