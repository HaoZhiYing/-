using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZYEntityFrameWork.Reflection
{
    using System.Reflection;
    public class BaseHelper
    {
        public BaseHelper() { }

        /// <summary>
        /// 获取类中所有的公共属性 PropertyInfo集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetAllPropertyInfo(Type t)
        {
            return t.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).ToList();
        }

        /// <summary>
        /// 获取指定的公共属性 PropertyInfo
        /// </summary>
        /// <param name="t"></param>
        /// <param name="filed"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo(Type t, string filed)
        {
            return t.GetProperty(filed);
        }

        /// <summary>
        /// 设置给定字段的值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="filed"></param>
        /// <param name="value"></param>
        public static void SetValue(Type t, string filed, string value)
        {
            BaseHelper.GetPropertyInfo(t, filed).SetValue(t, value);
        }

        /// <summary>
        /// 获取给定字段的值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="filed"></param>
        public static void GetValue(Type t, string filed)
        {
            BaseHelper.GetPropertyInfo(t, filed).GetValue(t);
        }

    }
}
