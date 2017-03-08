using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZYEntityFrameWork.CustomAttribute
{
    /// <summary>
    /// 验证字符串长度
    /// </summary>
    public class StringLengthSignAttribute : BaseSignAttribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public StringLengthSignAttribute(int minLength)
        {
            this.MinLength = minLength;
        }
    }
}
