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
    /// 插入语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AddSqlString<T> : AbstractSqlContext<T> where T : BaseModel, new()
    {
        //INSERT INTO TAB COL VALUES () 

        public AddSqlString() { }

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
            throw new NotImplementedException();
        }

        public override SQL_Container GetSqlString(MemberInitExpression mie, T where)
        {
            throw new NotImplementedException();
        }

        public override SQL_Container GetSqlString(MemberInitExpression mie, string where)
        {
            throw new NotImplementedException();
        }

        private SQL_Container GetSQL(MemberInitExpression mie)
        {
            var TableName = mie.Type.Name;
            var col = new List<string>();
            var val = new List<string>();
            var li = new List<SQL_Container>();
            var list = mie.Bindings.ToList().FindAll(item => ExpressionHelper.DealExpress(((MemberAssignment)item).Expression) != null && ExpressionHelper.DealExpress(((MemberAssignment)item).Expression) != "null");
            SqlParameter[] sparr = new SqlParameter[list.Count];
            foreach (MemberAssignment item in list)
            {
                var value = ExpressionHelper.DealExpress(item.Expression);
                var key = item.Member.Name;
                col.Add(key); val.Add("@" + key + "");
                sparr.SetValue(new SqlParameter() { ParameterName = key, Value = value }, list.IndexOf(item));
            }
            string sql = string.Format(" INSERT INTO {0} ({1}) VALUES ({2}) ", TableName, string.Join(",", col), string.Join(",", val));
            return new SQL_Container(sql, sparr);
        }

    }
}
