using TBSS.Model;

namespace TBSS.Repositories.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers(int? customerId, int? projectId);
        User GetUserById(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
