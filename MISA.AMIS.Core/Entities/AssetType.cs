using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.HCSH.Core.Entities
{
    /// <summary>
    /// loại tài sản
    /// </summary>
    public class AssetType: BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid AssetTypeId { get; set; }
        /// <summary>
        /// mã loại
        /// </summary>
        public string AssetTypeCode { get; set; }
        /// <summary>
        /// tên loại
        /// </summary>
        public string AssetTypeName { get; set; }
        /// <summary>
        /// ghi chú
        /// </summary>
        public string Description { get; set; }
    }
}
