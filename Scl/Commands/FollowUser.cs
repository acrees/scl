using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Commands
{
    public class FollowUser : IFollowUser
    {
        public void Execute(User user, User userToFollow)
        {
            user.Follow(userToFollow);
        }
    }
}
