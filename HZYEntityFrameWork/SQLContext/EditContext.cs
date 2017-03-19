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
    public class EditContext<T> where T : BaseModel, new()
    {
        Context.EditSqlString<T> sqlstring = new Context.EditSqlString<T>();
        CommitContext commit = new CommitContext();
        public EditContext() { }

        private SQL_Container GetSql(T entity)
        {
            var list = new List<MemberBinding>();
            var pK = entity.EH.GetPropertyInfo(entity, entity.EH.GetKeyName(entity));
            var fileds = entity.EH.GetAllPropertyInfo(entity);
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(entity), item.PropertyType)));
            return sqlstring.GetSqlString(Expression.MemberInit(Expression.New(entity.GetType()), list), " AND " + pK.Name + "='" + pK.GetValue(entity) + "' ");
        }

        private SQL_Container GetSql(T entity, string where)
        {
            var list = new List<MemberBinding>();
            var pK = entity.EH.GetPropertyInfo(entity, entity.EH.GetKeyName(entity));
            var fileds = entity.EH.GetAllPropertyInfo(entity);
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(entity), item.PropertyType)));
            return sqlstring.GetSqlString(Expression.MemberInit(Expression.New(entity.GetType()), list), where);
        }

        private SQL_Container GetSql(T entity, T where)
        {
            var list = new List<MemberBinding>();
            var pK = entity.EH.GetPropertyInfo(entity, entity.EH.GetKeyName(entity));
            var fileds = entity.EH.GetAllPropertyInfo(entity);
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(entity), item.PropertyType)));
            return sqlstring.GetSqlString(Expression.MemberInit(Expression.New(entity.GetType()), list), where);
        }

        private SQL_Container GetSql(T entity, Expression<Func<T, bool>> where)
        {
            var list = new List<MemberBinding>();
            var pK = entity.EH.GetPropertyInfo(entity, entity.EH.GetKeyName(entity));
            var fileds = entity.EH.GetAllPropertyInfo(entity);
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(entity), item.PropertyType)));
            return sqlstring.GetSqlString(Expression.MemberInit(Expression.New(entity.GetType()), list), where);
        }

        public bool Edit(T entity)
        {
            var sql = this.GetSql(entity);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Edit(T entity, string where)
        {
            var sql = this.GetSql(entity, where);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Edit(T entity, T where)
        {
            var sql = this.GetSql(entity, where);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Edit<M>(Expression<Func<M, M>> set, Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            var sql = sqlstring.GetSqlString(set.Body as MemberInitExpression, where);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Edit(T entity, ref List<SQL_Container> li)
        {
            var sql = this.GetSql(entity);
            li.Add(sql);
            return true;
        }

        public bool Edit(T entity, string where, ref List<SQL_Container> li)
        {
            var sql = this.GetSql(entity, where);
            li.Add(sql);
            return true;
        }

        public bool Edit(T entity, T where, ref List<SQL_Container> li)
        {
            var sql = this.GetSql(entity, where);
            li.Add(sql);
            return true;
        }

        public bool Edit<M>(Expression<Func<M, M>> set, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
        {
            var sql = sqlstring.GetSqlString(set.Body as MemberInitExpression, where);
            li.Add(sql);
            return true;
        }

    }
}
