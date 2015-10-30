using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Contracts
{
    public interface ICurrentTimeProvider
    {
        DateTime CurrentTime();
    }
}
