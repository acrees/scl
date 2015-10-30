using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Test.Doubles
{
    public class FollowUserSpy : IFollowUser
    {
        public User UserCalledWith { get; private set; }
        public User UserToFollowCalledWith { get; private set; }

        public void Execute(User user, User userToFollow)
        {
            UserCalledWith = user;
            UserToFollowCalledWith = userToFollow;
        }
    }
}
