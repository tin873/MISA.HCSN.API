using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSN.API.Controllers
{
    public class AssetTypeController : MisaBaseController<AssetType>
    {
        private IAssetTypeService _assetTypeService;
        public AssetTypeController(IAssetTypeService assetTypeService) : base(assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }
    }
}
