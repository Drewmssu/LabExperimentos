using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDataLayer;
using Repository;

namespace DemoService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            this.userRepository = new EFUserRepository();
        }

        public bool Authenticate(string username, string password) => userRepository.Authenticate(username, password);
    }
}
