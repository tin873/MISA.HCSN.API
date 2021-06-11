using System;

namespace MISA.HCSH.Core.Entities
{
    /// <summary>
    /// phòng ban
    /// </summary>
    public class Department:BaseEntity
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// ghi chú
        /// </summary>
        public string Description { get; set; }
    }
}
