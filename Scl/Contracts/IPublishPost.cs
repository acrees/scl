using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Contracts
{
    public interface IPublishPost
    {
        void Execute(User user, string message);
    }
}
