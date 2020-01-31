using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zeux.Test.Models;
using Zeux.Test.Services;

namespace Zeux.Test.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("[action]/{type}")]
        public async Task<IEnumerable<Asset>> Get(string type)
        {

            if (string.IsNullOrWhiteSpace(type) || type.ToLower() == "all")
                return await _assetService.Get();

            return await _assetService.Get(type);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            return await _assetService.GetTypes();
        }
    }
}
