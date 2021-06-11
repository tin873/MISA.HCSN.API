using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface;
using MISA.HCSH.Core.Interface.IService;

namespace MISA.HCSH.Core.Service
{
    public class AssetIncreaseService: BaseService<AssetIncrease>, IAssetIncreaseService
    {
        public AssetIncreaseService(IBaseRepository<AssetIncrease> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
    }
}
