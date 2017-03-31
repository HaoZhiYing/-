using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using DBAccess.Entity;

namespace DBAccess.CheckEntity
{
    /// <summary>
    /// 验证
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CheckContext<T> where T : BaseModel, new()
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }

        private CheckContext() { }

        private string _ConnectionString { get; set; }

        public CheckContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public bool Check(T entity)
        {
            return true;
        }







    }
}
