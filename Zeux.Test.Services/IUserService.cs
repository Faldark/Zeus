using System.Threading.Tasks;
using Zeux.Test.Server.Models;

namespace Zeux.Test.Services
{
    public interface IUserService
    {
        Task<User> FindUser(string user, string password);
    }
}