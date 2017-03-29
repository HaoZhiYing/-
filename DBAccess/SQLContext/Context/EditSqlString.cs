using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using System.Data.SqlClient;
using DBAccess.Entity;
using DBAccess.ExpressionTree;

namespace DBAccess.SQLContext.Context
{
    /// <summary>
    /// 修改语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EditSqlString<T> : AbstractSqlContext<T> where T : BaseModel, new()
    {
        // UPDATE TAB SET  WHERE 1=1 
        List<SqlParameter> list_sqlpar = new List<SqlParameter>();

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
            return this.GetSQL(mie, " AND " + this.GetWhereString(where, ref list_sqlpar));
        }

        public override SQL_Container GetSqlString(MemberInitExpression mie, T where)
        {
            return this.GetSQL(mie, this.GetWhereString(where, ref list_sqlpar));
        }

        public override SQL_Container GetSqlString(MemberInitExpression mie, string where)
        {
            return this.GetSQL(mie, where);
        }

        private SQL_Container GetSQL(MemberInitExpression mie, string where)
        {
            var TableName = mie.Type.Name;
            var set = new List<string>();
            var list = mie.Bindings.ToList();
            foreach (MemberAssignment item in list)
            {
                var value = ExpressionHelper.DealExpress(item.Expression);
                var key = item.Member.Name;
                set.Add(key + "=@" + key + "");
                list_sqlpar.Add(new SqlParameter() { ParameterName = key, Value = value });
            }
            string sql = string.Format(" UPDATE {0} SET {1} WHERE 1=1 {2}", TableName, string.Join(",", set), where);
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }




    }
}
