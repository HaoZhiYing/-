using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using HZYEntityFrameWork.Reflection;

namespace HZYEntityFrameWork.Entity
{
    public class BaseModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName = string.Empty;

        /// <summary>
        /// 设置不验证的字段集合
        /// </summary>
        public List<string> NotChecks = new List<string>();

        /// <summary>
        /// 设置插入Null值的字段集合
        /// </summary>
        public List<string> InsertNullFiles = new List<string>();

        /// <summary>
        /// 实体操作Helper
        /// </summary>
        public readonly EntityHelper<BaseModel> EH = new EntityHelper<BaseModel>();

        public BaseModel()
        {
            NotChecks = new List<string>();
            InsertNullFiles = new List<string>();
            EH = new EntityHelper<BaseModel>();
        }

    }
}
