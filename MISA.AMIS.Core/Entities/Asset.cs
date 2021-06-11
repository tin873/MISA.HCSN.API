using System;

namespace MISA.HCSH.Core.Entities
{
    /// <summary>
    /// Thông tin tài sản
    /// </summary>
    public class Asset: BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        [Primary]
        public Guid AssetId { get; set; }
        /// <summary>
        /// mã tài sản
        /// </summary>
        [Require("Mã tài sản không được để trống!")]
        [MaxLength(20,"Mã tài sản chỉ được để tối đa 20 ký tự.")]
        public string AssetCode { get; set; }
        /// <summary>
        /// tên tai sản
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// loại tài sản
        /// </summary>
        public Guid? AssetTypeId { get; set; }
        /// <summary>
        /// phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// ngày ghi tăng
        /// </summary>
        public DateTime? IncreaseDate { get; set; }
        /// <summary>
        /// thời gian sử dụng
        /// </summary>
        public decimal? TimeUse { get; set; }
        /// <summary>
        /// tỉ lệ hao mòn
        /// </summary>
        public decimal? WearRate { get; set; }
        /// <summary>
        /// giá gốc
        /// </summary>
        public decimal? OriginalPrice { get; set; }
        /// <summary>
        /// giá trị hao mòn năm
        /// </summary>
        public decimal? WearValue { get; set; }
        /// <summary>
        /// tình trạng (đang sử dụng 1 ; không sử dụng 0)
        /// </summary>
        public bool? IsUsed { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetTypeName { get; set; }
    }
}
