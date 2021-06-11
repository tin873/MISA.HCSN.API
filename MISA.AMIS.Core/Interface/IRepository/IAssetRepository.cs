using MISA.HCSH.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.HCSH.Core.Interface
{
    public interface IAssetRepository: IBaseRepository<Asset>
    {
        public bool CheckStoreCode(Guid? assetId, string assetCode, string functionName);
        /// <summary>
        /// Lấy dữ liệu theo điều kiện( tìm kiếm)
        /// </summary>
        /// <param name="AssetCode">Mã tài sản</param>
        /// <param name="AssetName">Tên tài sản</param>
        /// <returns></returns>
        IEnumerable<Asset> GetEntitiesFilter(string input);
    }
}
