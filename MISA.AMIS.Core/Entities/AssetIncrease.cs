using System;

namespace MISA.HCSH.Core.Entities
{
    /// <summary>
    /// Ghi tăng tài sản
    /// </summary>
    public class AssetIncrease: BaseEntity
    {
        /// <summary>
        /// mã ghi tăng
        /// </summary>
        public Guid AssetIncreaseId { get; set; }
        /// <summary>
        /// mã
        /// </summary>
        public string ExhibitCode { get; set; }
        /// <summary>
        /// ngày ra mắt
        /// </summary>
        public DateTime? ExhibitDate { get; set; }
        /// <summary>
        /// ngày ghi tăng
        /// </summary>
        public DateTime IncreaseDate { get; set; }
        /// <summary>
        /// ghi chú
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// chi tiết ghi tăng
        /// </summary>
        public string IncreaseDetail { get; set; }
    }
}
