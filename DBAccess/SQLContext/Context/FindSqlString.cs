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
    public class FindSqlString<T> : AbstractSqlContext<T> where T : BaseModel, new()
    {
        List<SqlParameter> list_sqlpar = new List<SqlParameter>();

        public FindSqlString() { }

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


        public SQL_Container GetSqlStringOrderBy(MemberInitExpression mie, string orderby)
        {
            return this.GetSQL(mie, ExpressionHelper.DealExpress(mie));
        }

        private SQL_Container GetSQL(MemberInitExpression mie, string where)
        {
            var list_par = new List<SqlParameter>();
            var TableName = mie.Type.Name;
            var list = mie.Bindings.ToList().FindAll(item => ExpressionHelper.DealExpress(((MemberAssignment)item).Expression) != null && ExpressionHelper.DealExpress(((MemberAssignment)item).Expression) != "null");

            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 {2}", "*", TableName, where);
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }

        private SQL_Container GetSQL(MemberInitExpression mie, string where, string orderby)
        {
            var TableName = mie.Type.Name;
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 {2}", "*", TableName, where);
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }


    }
}
