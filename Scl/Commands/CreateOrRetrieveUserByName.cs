using Scl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scl.Commands
{
    public class CreateOrRetrieveUserByName : ICreateOrRetrieveUserByName
    {
        public CreateOrRetrieveUserByName(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Execute(string name)
        {
            var user = _repository.Get(name);
            if (user == null)
            {
                user = new User(name);
                _repository.Add(user);
            }
            return user;
        }

        private IUserRepository _repository;
    }
}
