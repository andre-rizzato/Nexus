
using nexus.Models;


namespace nexus.Repositories.Interfaces
{

    public interface IUserRepository
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        User Add(User user);
        User Update(User user);
        int Delete(User user);
    }
}