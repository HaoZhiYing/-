using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZYEntityFrameWork.CustomAttribute
{
    public class CRepeatAttribute
    {
        /// <summary>
        /// 要追加的 Where 条件 例如： and 1=1  and filed1='{filed1}'
        /// </summary>
        public string Where { get; set; }
        public CRepeatAttribute()
        {

        }


    }
}
