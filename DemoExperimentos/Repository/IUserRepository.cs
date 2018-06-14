
namespace Repository
{
    public interface IUserRepository
    {
        bool Authenticate(string username, string password);
    }
}
