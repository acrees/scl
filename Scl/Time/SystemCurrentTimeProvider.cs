using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Time
{
    public class SystemCurrentTimeProvider : ICurrentTimeProvider
    {
        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}
