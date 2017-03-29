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
        public readonly List<string> NotChecks = new List<string>();

        /// <summary>
        /// 属性set临时容器
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

        /// <summary>
        /// set 
        /// </summary>
        /// <param name="FiledName"></param>
        /// <param name="Value"></param>
        private void Set(string FiledName, object Value)
        {
            if (Value != null && Value is string)
            {
                if (Value.Equals("null"))
                    Value = null;
            }
            if (fileds.ContainsKey(FiledName))
                fileds[FiledName] = Value;
            else
                fileds.Add(FiledName, Value);
        }

        /// <summary>
        /// 添加不验证字段
        /// </summary>
        public void AddNotChecks(params string[] fileds)
        {
            foreach (var item in fileds)
                NotChecks.Add(item);
        }

    }
}
