using MISA.HCSH.Core.CustomException;
using MISA.HCSH.Core.Entities;
using MISA.HCSH.Core.Interface;
using MISA.HCSH.Core.Interface.IService;
using MISA.HCSH.Core.Resource;
using MISA.HCSH.Core.Respon;
using System;

namespace MISA.HCSH.Core.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        #region property
        protected IBaseRepository<T> _baseRepository;
        protected ResponResult _responResult;
        #endregion
        #region contructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _responResult = new ResponResult();
        }
        #endregion
        #region methods
        public ResponResult Delete(Guid entityId)
        {
            var result = _baseRepository.GetById(entityId);
            if(result != null)
            {
                _responResult.Data = _baseRepository.Delete(entityId);
                _responResult.IsSuccess = true;
            }
            else
            {
                _responResult.Data = -1;
                _responResult.UserMsg.Add(ResourceMessage.Error_NotExits_Code);
                _responResult.ErrorCode = Enum.ErrorCode.NOCONTENT;
                _responResult.IsSuccess = false;
            }
            return _responResult;
        }

        public ResponResult GetById(Guid entityId)
        {
            var result = _baseRepository.GetById(entityId);
            if(result != null)
            {
                _responResult.Data = result;
                _responResult.IsSuccess = true;
            }  
            else
            {
                _responResult.IsSuccess = false;
                _responResult.UserMsg.Add(ResourceMessage.Error_NotFound);
            }
            return _responResult;
        }

        public ResponResult GetEntities()
        {
            var result = _baseRepository.GetEntities();
            if (result != null)
            {
                _responResult.Data = result;
                _responResult.IsSuccess = true;
            }
            else
            {
                _responResult.IsSuccess = false;
                _responResult.UserMsg.Add(ResourceMessage.Error_NotFound);
                _responResult.DevMsg = ResourceMessage.NoContent;
                _responResult.ErrorCode = Enum.ErrorCode.NOCONTENT;
            }
            return _responResult;
        }

        public ResponResult Insert(T entity)
        {
            if (ValidateObject(entity))
            {
                _responResult.Data = _baseRepository.Insert(entity);
                _responResult.IsSuccess = true;
                _responResult.UserMsg.Add(ResourceMessage.Insert_Success);
                _responResult.ErrorCode = Enum.ErrorCode.ISVALID;
                return _responResult;
            }
            else
            {
                _responResult.IsSuccess = false;
                _responResult.ErrorCode = Enum.ErrorCode.EXCEPTION;
                _responResult.DevMsg = ResourceMessage.Error_Insert;
                return _responResult;
            }
        }

        public ResponResult Update(T entity)
        {
            if (ValidateObject(entity))
            {
                _responResult.Data = _baseRepository.Update(entity);
                _responResult.IsSuccess = true;
                _responResult.UserMsg.Add(ResourceMessage.Update_Success);
                _responResult.ErrorCode = Enum.ErrorCode.ISVALID;
                return _responResult;
            }
            else
            {
                _responResult.IsSuccess = false;
                _responResult.ErrorCode = Enum.ErrorCode.EXCEPTION;
                _responResult.DevMsg = ResourceMessage.Error_Update;
                return _responResult;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập vào trước khi thực hiện các chức năng Insert Update
        /// </summary>
        /// <param name="entity"></param>
        private bool ValidateObject(T entity)
        {
            //lấy ra các property của class
            var properties = typeof(T).GetProperties();
            // duyệt từng property 
            foreach (var property in properties)
            {
                //kiểm tra thuộc tính xem có require không
                var propertyValue = property.GetValue(entity);
                //lấy tên trường
                var propertyName = property.Name;
                
                var propertyRequireds = property.GetCustomAttributes(typeof(Require), true);

                var propertyMaxLengths = property.GetCustomAttributes(typeof(MaxLength), true);

                //kiểm tra các thuộc tính bắt buộc nhập
                if(propertyRequireds.Length > 0)
                {
                    if(propertyValue == null)
                    {
                        throw new CustomValidateException($"Không tìm thấy giá trị của trường [{propertyName}]");
                    }
                    //lấy ra thông báo tùy chọn
                    var useMsg = (propertyRequireds[0] as Require).UseMsg;
                    if(string.IsNullOrEmpty(useMsg))
                    {
                        useMsg = $"{propertyName}";
                        if(string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            var errorMsg = $"Thông tin {useMsg} không được để trống";
                            _responResult.UserMsg.Add(errorMsg);
                            return false;
                        }    
                    }
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        if (string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                            var errorMsg = $"{useMsg}";
                            _responResult.UserMsg.Add(errorMsg);
                            return false;
                        }
                    }
                }
                
                //kiểm tra độ dài tối đa 
                if(propertyMaxLengths.Length > 0)
                {
                    // Lấy ra độ dài tối đa cho phép của chuỗi:
                    var maxLength = (propertyMaxLengths[0] as MaxLength).Length;
                    //lấy ra thông báo tùy chọn
                    var useMsg = (propertyMaxLengths[0] as MaxLength).UseMsg;
                    if(string.IsNullOrEmpty(useMsg))
                    {
                        useMsg = $"{propertyName}";
                        if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                        {
                            var errorMsg = $"{useMsg} chỉ có thể để {maxLength} ký tự";
                            _responResult.UserMsg.Add(errorMsg);
                            return false;
                        }
                    }  
                    else
                    {
                        if (propertyValue != null && propertyValue.ToString().Length > maxLength)
                        {
                            _responResult.UserMsg.Add(useMsg);
                            return false;
                        }
                    }    
                }
            }
            return true;
        }
        #endregion
    }
}
