using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using HZYEntityFrameWork.Reflection;
using HZYEntityFrameWork.Entity;
using System.Dynamic;

namespace HZYEntityFrameWork.SQLContext
{
    public class FindContext<T> where T : BaseModel, new()
    {
        Context.FindSqlString<T> sqlstring = new Context.FindSqlString<T>();
        CommitContext commit = new CommitContext();
        public FindContext() { }

        private SQL_Container GetSql<M>(M where, string orderby) where M : BaseModel, new()
        {
            var list = new List<MemberBinding>();
            var fileds = where.EH.GetAllPropertyInfo(where).FindAll(item => item.GetValue(where) != null || item.GetValue(where) != "null");
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(where), item.PropertyType)));
            return sqlstring.GetSqlStringOrderBy(Expression.MemberInit(Expression.New(where.GetType()), list), orderby);
        }

        private SQL_Container GetSql(T where)
        {
            var list = new List<MemberBinding>();
            var fileds = where.EH.GetAllPropertyInfo(where).FindAll(item => item.GetValue(where) != null || item.GetValue(where) != "null");
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(where), item.PropertyType)));
            return sqlstring.GetSqlString(Expression.MemberInit(Expression.New(where.GetType()), list));
        }



        public M Find<M>(M entity, string orderby) where M : BaseModel, new()
        {
            var sql = this.GetSql(entity, orderby);
            return null;
        }















    }
}
