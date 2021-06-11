using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface;
using MISA.HCSH.Core.Interface.IService;
using MISA.HCSH.Core.Resource;
using MISA.HCSH.Core.Respon;

namespace MISA.HCSH.Core.Service
{
    public class AssetService : BaseService<Asset>, IAssetService
    {
        protected IAssetRepository _assetRepository;
        public AssetService(IBaseRepository<Asset> baseRepository, IAssetRepository assetRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _assetRepository = assetRepository;
            _responResult = new ResponResult();
        }
        public ResponResult GetEntitiesFilter(string input)
        {
            var entities = _assetRepository.GetEntitiesFilter(input);


            if (entities != null)
            {
                _responResult.Data = entities;
                _responResult.ErrorCode = Enum.ErrorCode.NONE;
                _responResult.UserMsg.Add(ResourceMessage.Get_Success);
            }
            else
            {
                _responResult.IsSuccess = false;
                _responResult.UserMsg.Add(ResourceMessage.NotFound);
                _responResult.DevMsg = ResourceMessage.NoContent;
                _responResult.ErrorCode = Enum.ErrorCode.NOCONTENT;
            }

            return _responResult;
        }
    }
}
