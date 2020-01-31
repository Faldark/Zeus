using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Server.Models;

namespace Zeux.Test.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly FakeContext _context = new FakeContext();

        public async Task<User> FindUser(string user, string password)
        {
            return await Task.Run(() => _context.Users.FirstOrDefault(x => x.Login == user && x.Password == password));
        }
    }
}
