using System;

namespace MISA.HCSH.Core.Entities
{
    /// <summary>
    /// check bắt nhập 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Require: Attribute
    {
        public string UseMsg = string.Empty;
        public Require(string useMsg= "")
        {
            UseMsg = useMsg;
        }
    }
    /// <summary>
    /// check độ dài tối đa của chuỗi
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength: Attribute
    {
        public int Length = 0;
        public string UseMsg = string.Empty;

        public MaxLength(int maxLength = 0, string useMsg = "")
        {
            Length = maxLength;
            UseMsg = useMsg;
        }

        public string ErrorMaxLength
        {
            get
            {
                if(Length != 0)
                {
                    return UseMsg;
                }    
                else
                {
                    return null;
                }                    
            }
        }
    }
    // Khóa 
    [AttributeUsage(AttributeTargets.Property)]
    public class Primary : Attribute
    {
    }
}
