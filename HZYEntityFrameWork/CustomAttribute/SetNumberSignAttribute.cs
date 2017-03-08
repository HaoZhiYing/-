using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZYEntityFrameWork.CustomAttribute
{
    /// <summary>
    /// 编号 标记
    /// </summary>
    public class SetNumberSignAttribute : BaseSignAttribute
    {
        /// <summary>
        /// 编号长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 编号标记
        /// </summary>
        /// <param name="length">编号长度</param>
        public SetNumberSignAttribute(int length)
        {
            this.Length = length;
        }

    }
}
