using Microsoft.AspNetCore.Mvc;
using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSN.API.Controllers
{
    public class AssetController : MisaBaseController<Asset>
    {
        private IAssetService _assetService;
        public AssetController(IAssetService assetService) : base(assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("Filter")]
        public IActionResult Get(string input)
        {
            var responseResult = _assetService.GetEntitiesFilter(input);
            return Ok(responseResult);
        }
    }
}
