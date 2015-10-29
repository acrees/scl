using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Persistance
{
    public class UserRepository : IUserRepository
    {
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string username)
        {
            return _users.FirstOrDefault(u => u.Name == username);
        }

        private List<User> _users = new List<User>();
    }
}
