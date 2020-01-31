using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeux.Test.Models;
using Zeux.Test.Repositories;

namespace Zeux.Test.Services
{
    public class AssetService: IAssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Asset>> Get()
        {
            return await _repository.Get();
        }

        public async Task<IEnumerable<Asset>> Get(string type)
        {
            return await _repository.Get(type);
        }

        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await _repository.GetTypes();
        }
    }
}
