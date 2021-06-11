using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSN.API.Controllers
{
    public class AssetIncreaseController : MisaBaseController<AssetIncrease>
    {
        private IAssetIncreaseService _assetIncreaseService;
        public AssetIncreaseController(IAssetIncreaseService assetIncreaseService) : base(assetIncreaseService)
        {
            _assetIncreaseService = assetIncreaseService;
        }
    }
}
