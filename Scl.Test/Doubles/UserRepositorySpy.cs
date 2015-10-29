using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class UserRepositorySpy : IUserRepository
    {
        public User AddCalledWith { get; set; }

        public void Add(User user)
        {
            AddCalledWith = user;
        }

        public User Get(string name)
        {
            if (name == "Alice") return new User("Alice");
            return null;
        }
    }
}
