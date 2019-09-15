

namespace Schindler.ElavatorStatus.Domain
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
