using TBSS.Model;

namespace TBSS.Repositories.IRepositories
{
    public interface IAuthRepository
    {
        User Authenticate(string username, string password);
    }
}
