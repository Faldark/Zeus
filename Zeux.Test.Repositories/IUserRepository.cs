using System.Threading.Tasks;
using Zeux.Test.Server.Models;

namespace Zeux.Test.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindUser(string user, string password);
    }
}
