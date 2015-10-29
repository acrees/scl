using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class PrintPostsSpy : IPrintPosts
    {
        public User LastCalledWith;

        public void Execute(User user)
        {
            LastCalledWith = user;
        }
    }
}
