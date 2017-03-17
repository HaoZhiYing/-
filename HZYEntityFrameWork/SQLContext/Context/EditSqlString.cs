using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using System.Data.SqlClient;
using HZYEntityFrameWork.Entity;
using HZYEntityFrameWork.ExpressionTree;

namespace HZYEntityFrameWork.SQLContext.Context
{
    /// <summary>
    /// 修改语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EditSqlString<T> : AbstractSqlContext<T> where T : BaseModel, new()
    {
        // UPDATE TAB SET  WHERE 1=1 

        public EditSqlString() { }

        /// <summary>
        /// 获取sql语句
        /// </summary>
        /// <param name="mie"></param>
        /// <returns></returns>
        public override SQL_Container GetSqlString(MemberInitExpression mie)
        {
            throw new NotImplementedException();
        }

        public override SQL_Container GetSqlString<M>(MemberInitExpression mie, Expression<Func<M, bool>> where)
        {
            return this.GetSQL(mie, this.GetWhereString(where));
        }

        public override SQL_Container GetSqlString(MemberInitExpression mie, T where)
        {
            return this.GetSQL(mie, this.GetWhereString(where));
        }

        public override SQL_Container GetSqlString(MemberInitExpression mie, string where)
        {
            return this.GetSQL(mie, where);
        }

        private SQL_Container GetSQL(MemberInitExpression mie, string where)
        {
            var TableName = mie.Type.Name;
            var set = new List<string>();
            var li = new List<SQL_Container>();
            var list = mie.Bindings.ToList();
            SqlParameter[] sparr = new SqlParameter[list.Count];
            foreach (MemberAssignment item in list)
            {
                var value = ExpressionHelper.ExpressionRouter(item.Expression);
                var key = item.Member.Name;
                set.Add(key + "=@" + key + "");
                sparr.SetValue(new SqlParameter() { ParameterName = key, Value = value }, list.IndexOf(item));
            }
            string sql = string.Format(" UPDATE {0} SET {1} WHERE 1=1 {2}", TableName, string.Join(",", set), where);
            return new SQL_Container(sql, sparr);
        }




    }
}
