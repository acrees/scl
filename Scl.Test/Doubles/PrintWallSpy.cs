using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class PrintWallSpy : IPrintWall
    {
        public User LastCalledWith { get; private set; }

        public void Execute(User user)
        {
            LastCalledWith = user;
        }
    }
}
