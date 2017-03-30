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
    /// 删除语句
    /// </summary>
    public class DeleteSqlString<T> : AbstractSqlContext<T> where T : BaseModel, new()
    {
        List<SqlParameter> list_sqlpar;

        public DeleteSqlString()
        {
            list_sqlpar = new List<SqlParameter>();
        }

        /// <summary>
        /// 获取sql语句
        /// </summary>
        /// <param name="mie"></param>
        /// <returns></returns>
        public override SQL_Container GetSqlString(T entity)
        {
            return this.GetSQL(entity);
        }

        public SQL_Container GetSqlString<M>(T entity, Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            return this.GetSQL(entity, " AND " + this.GetWhereString(where, ref list_sqlpar));
        }

        public SQL_Container GetSqlString<M>(T entity, M where) where M : BaseModel, new()
        {
            return this.GetSQL(entity, this.GetWhereString(where, ref list_sqlpar));
        }

        public SQL_Container GetSqlString(T entity, string where)
        {
            return this.GetSQL(entity, where);
        }

        private SQL_Container GetSQL(T entity)
        {
            var TableName = entity.TableName;
            var list = entity.fileds.ToList();
            var where = new List<string>();
            foreach (var item in list)
            {
                var value = item.Value;
                var key = item.Key;
                where.Add(key + "=@" + key + "");

                list_sqlpar.Add(new SqlParameter() { ParameterName = key, Value = value });
            }
            string sql = string.Format(" DELETE FROM {0} WHERE 1=1 {2} ", TableName, string.Join(" AND ", where));
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }

        private SQL_Container GetSQL(T entity, string where)
        {
            var TableName = entity.TableName;
            string sql = string.Format(" DELETE FROM {0} WHERE 1=1 {1} ", TableName, where);
            return new SQL_Container(sql, list_sqlpar.ToArray());
        }

    }
}
