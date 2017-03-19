using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Linq.Expressions;
using HZYEntityFrameWork.Entity;
using HZYEntityFrameWork.ExpressionTree;

namespace HZYEntityFrameWork.SQLContext
{
    public abstract class AbstractSqlContext<T> : ISqlContext<T> where T : Entity.BaseModel, new()
    {
        // public abstract string GetSqlString(T entity);
        public abstract SQL_Container GetSqlString(MemberInitExpression mie);

        public abstract SQL_Container GetSqlString<M>(MemberInitExpression mie, Expression<Func<M, bool>> where) where M : BaseModel, new();

        public abstract SQL_Container GetSqlString(MemberInitExpression mie, T where);

        public abstract SQL_Container GetSqlString(MemberInitExpression mie, string where);

        /// <summary>
        /// 得到where语句
        /// </summary>
        /// <param name="model">需要拼接成字符串的实体</param>
        /// <returns></returns>
        public string GetWhereString(T entity, ref List<SqlParameter> list_sqlpar)
        {
            var where = string.Empty;
            var list = entity.EH.GetAllPropertyInfo(entity).FindAll(item => item.GetValue(entity) != null && item.GetValue(entity).ToString().ToLower() != "null");
            foreach (var item in list)
            {
                where += " AND " + item.Name + "=@" + item.GetValue(entity) + " ";
                list_sqlpar.Add(new SqlParameter() { ParameterName = item.Name, Value = item.GetValue(entity) });
            }
            return where;
        }

        /// <summary>
        /// 得到where语句
        /// </summary>
        /// <returns></returns>
        public string GetWhereString(string where)
        {
            return where;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public string GetWhereString<M>(Expression<Func<M, bool>> where, ref List<SqlParameter> list_sqlpar) where M : BaseModel, new()
        {
            string _where = string.Empty;
            if (where.Body is BinaryExpression)
            {
                BinaryExpression be = ((BinaryExpression)where.Body);
                _where = ExpressionHelper.DealExpress(where.Body);
                //_where = ExpressionHelper.BinarExpressionProvider(be.Left, be.Right, be.NodeType);
            }
            else
                throw new Exception(" where 条件语法错误! ");
            return _where;
        }



    }
}
