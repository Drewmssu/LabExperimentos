using DemoDataLayer;
using DemoLogic;
using System.Linq;

namespace Repository
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ExperimentosEntities context = new ExperimentosEntities();
        public bool Authenticate(string username, string password)
        {
            var pw = CipherLogic.Encrypt(password);
            var user = context.User.FirstOrDefault(x => x.Usuario == username &&
                                                        x.Password == pw);

            return user is null ? false : true;
        }
    }
}
