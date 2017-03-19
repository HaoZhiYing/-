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
    /// 删除语句
    /// </summary>
    public class DeleteSqlString<T> : AbstractSqlContext<T> where T : BaseModel, new()
    {
        List<SqlParameter> list_sqlpar = new List<SqlParameter>();

        public DeleteSqlString() { }

        /// <summary>
        /// 获取sql语句
        /// </summary>
        /// <param name="mie"></param>
        /// <returns></returns>
        public override SQL_Container GetSqlString(MemberInitExpression mie)
        {
            return this.GetSQL(mie);
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
            string sql = string.Format(" DELETE FROM {0} WHERE 1=1 {2} ", TableName, where);
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }

        private SQL_Container GetSQL(MemberInitExpression mie)
        {
            var TableName = mie.Type.Name;
            var where = new List<string>();
            var list = mie.Bindings.ToList();
            foreach (MemberAssignment item in list)
            {
                var value = ExpressionHelper.DealExpress(item.Expression);
                var key = item.Member.Name;
                where.Add(key + "=@" + key + "");
                list_sqlpar.Add(new SqlParameter() { ParameterName = key, Value = value });
            }
            string sql = string.Format(" DELETE FROM {0} WHERE 1=1 {1} ", TableName, string.Join(",", where));
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }

    }
}
