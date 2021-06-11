using System;

namespace MISA.HCSH.Core.CustomException
{
    public class CustomValidateException : Exception
    {
        public string UserMessenger = string.Empty;
        public CustomValidateException(string msg, object data = null) : base(msg, new Exception())
        {
            this.UserMessenger = msg;
        }
    }
}
