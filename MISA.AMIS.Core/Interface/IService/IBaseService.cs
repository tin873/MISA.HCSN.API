using MISA.HCSH.Core.Respon;
using System;

namespace MISA.HCSH.Core.Interface.IService
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của bảng trong database
        /// </summary>
        /// <returns>Danh sách các đối tượng</returns>
        ResponResult GetEntities();

        /// <summary>
        /// Lấy thông tin của thực thể theo khóa chính
        /// </summary>
        /// <param name="entityId">ID của đối tượng</param>
        /// <returns>1 thực thể duy nhất có ID tương ứng truyền vào</returns>
        ResponResult GetById(Guid entityId);

        /// <summary>
        /// Thêm mới một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>Số bản ghi thêm mới được vào DB</returns>
        ResponResult Insert(T entity);

        /// <summary>
        /// Sửa thông tin của một đối tượng
        /// </summary>
        /// <param name="entity">Thực thể cần thêm mới</param>
        /// <returns>Số bản ghi đã được cập nhật nội dụng trong DB</returns>
        ResponResult Update(T entity);

        /// <summary>
        /// Xóa một bản ghi theo ID
        /// </summary>
        /// <param name="entityId">ID của đối tượng cần xóa</param>
        /// <returns>Số bản ghi đã xóa trong DB</returns>
        ResponResult Delete(Guid entityId);
    }
}
