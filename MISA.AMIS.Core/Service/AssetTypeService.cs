using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSH.Core.Service
{
    public class AssetTypeService: BaseService<AssetType>, IAssetTypeService
    {
        public AssetTypeService(IBaseRepository<AssetType> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
