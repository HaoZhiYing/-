using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZYEntityFrameWork.CustomAttribute
{
    /// <summary>
    /// 正则表达式验证
    /// </summary>
    public class RegularExpressionSignAttribute : BaseSignAttribute
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Pattern { get; set; }

        public RegularExpressionSignAttribute(string pattern)
        {
            this.Pattern = pattern;
        }
    }
}
