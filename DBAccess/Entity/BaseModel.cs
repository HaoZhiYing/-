using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using DBAccess.Reflection;

namespace DBAccess.Entity
{
    [AopEntity]
    public class BaseModel : ContextBoundObject
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
        /// 
        /// </summary>
        public readonly Dictionary<string, object> fileds = new Dictionary<string, object>();

        /// <summary>
        /// 实体操作Helper
        /// </summary>
        public readonly EntityHelper<BaseModel> EH = new EntityHelper<BaseModel>();

        public BaseModel()
        {
            NotChecks = new List<string>();
            fileds = new Dictionary<string, object>();
            EH = new EntityHelper<BaseModel>();
        }

        private void Set(string FiledName, object value)
        {
            //if (PropertyValues == null)
            //    PropertyValues = "";
            if (value != null && value is string)
            {
                if (value.Equals("null"))
                    value = DBNull.Value;
            }
            if (fileds.ContainsKey(FiledName))
                fileds[FiledName] = value;
            else
                fileds.Add(FiledName, value);
        }

    }
}
