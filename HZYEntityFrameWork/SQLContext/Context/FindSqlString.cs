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
            string sql = string.Format(" SELECT {0} FROM {1} WHERE 1=1 {2}", "", TableName, string.Join(",", set), where);
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }

        public string aa() { 
        
        }

    }
}
