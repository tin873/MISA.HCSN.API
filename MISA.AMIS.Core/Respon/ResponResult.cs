using MISA.HCSH.Core.Enum;
using System;
using System.Collections.Generic;

namespace MISA.HCSH.Core.Respon
{
    public class ResponResult
    {
        // thông báo thao tác thành công hay thất bại, default là true
        public bool IsSuccess { get; set; } = true;

        // nội dung thông báo cho người lập trình
        public string DevMsg { get; set; }

        // nội dung thông báo cho user
        public List<string> UserMsg { get; set; }

        // mã code lỗi của thao tác, mặc định ban đầu là NONE - không có lỗi
        public ErrorCode ErrorCode { get; set; } = ErrorCode.NONE;


        // thông tin tìm hiểu thêm cho dev
        public string MoreInfo { get; set; }

        // mã lỗi để tìm kiếm trên trang web nào đó ví dụ abc.com.vn
        public string TraceId { get; set; }

        // dữ liệu của kết quả trả về
        public object Data { get; set; }

        /// <summary>
        /// Xử lý lỗi ngoại lệ
        /// </summary>
        /// <param name="result"></param>
        /// <param name="ex"></param>
        public void OnException(ResponResult result, Exception ex)
        {
            result.UserMsg.Add(Resource.ResourceMessage.Exception_User);
            result.DevMsg = Resource.ResourceMessage.Exception_User;
            result.IsSuccess = false;
            result.ErrorCode = ErrorCode.EXCEPTION;
        }

        /// <summary>
        /// Xử lý lỗi dữ liệu sai
        /// </summary>
        /// <param name="result"></param>
        public void OnBadRequest(ResponResult result)
        {
            result.IsSuccess = false;
            result.ErrorCode = ErrorCode.BADREQUEST;
            result.DevMsg = Resource.ResourceMessage.Error_Input;
            result.UserMsg.Add(Resource.ResourceMessage.Error_Input);
        }
    }
}
