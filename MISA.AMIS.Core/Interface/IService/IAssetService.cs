using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Respon;

namespace MISA.HCSH.Core.Interface.IService
{
    public interface IAssetService:IBaseService<Asset>
    {
        /// <summary>
        /// Lấy dữ liệu theo điều kiện( tìm kiếm)
        /// </summary>
        /// <param name="AssetCode">Mã tài sản</param>
        /// <param name="AssetName">Tên tài sản</param>
        /// <returns></returns>
        ResponResult GetEntitiesFilter(string input);
    }
}
