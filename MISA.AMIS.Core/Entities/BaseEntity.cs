using System;

namespace MISA.HCSH.Core.Entities
{
    /// <summary>
    /// thông tin chung
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// ngày sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// người sửa đổi
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
