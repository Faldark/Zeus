using System.Threading.Tasks;
using Zeux.Test.Repositories;
using Zeux.Test.Server.Models;

namespace Zeux.Test.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> FindUser(string user, string password)
        {
            return await _repository.FindUser(user, password);
        }
    }
}
