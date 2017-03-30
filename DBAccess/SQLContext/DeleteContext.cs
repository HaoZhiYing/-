using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using DBAccess.Reflection;
using DBAccess.Entity;
using System.Dynamic;

namespace DBAccess.SQLContext
{
    public class DeleteContext<T> where T : BaseModel, new()
    {
        Context.DeleteSqlString<T> sqlstring;
        CommitContext commit;
        private DeleteContext() { }

        private string _ConnectionString { get; set; }

        public DeleteContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            commit = new CommitContext(_ConnectionString);
            sqlstring = new Context.DeleteSqlString<T>();
        }

        private SQL_Container GetSql(T entity)
        {
            return sqlstring.GetSqlString(entity);
        }

        private SQL_Container GetSql(T entity, string where)
        {
            return sqlstring.GetSqlString(entity, where);
        }

        private SQL_Container GetSql(T entity, T where)
        {
            return sqlstring.GetSqlString(entity, where);
        }

        private SQL_Container GetSql(T entity, Expression<Func<T, bool>> where)
        {
            return sqlstring.GetSqlString(entity, where);
        }

        public bool Delete(T entity)
        {
            var sql = this.GetSql(entity);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Delete(T entity, string where)
        {
            var sql = this.GetSql(entity, where);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Delete(T entity, T where)
        {
            var sql = this.GetSql(entity, where);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Delete<M>(T model, Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            var sql = sqlstring.GetSqlString(model, where);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return true;
            else
                return false;
        }

        public bool Delete(T entity, ref List<SQL_Container> li)
        {
            var sql = this.GetSql(entity);
            li.Add(sql);
            return true;
        }

        public bool Delete(T entity, string where, ref List<SQL_Container> li)
        {
            var sql = this.GetSql(entity, where);
            li.Add(sql);
            return true;
        }

        public bool Delete(T entity, T where, ref List<SQL_Container> li)
        {
            var sql = this.GetSql(entity, where);
            li.Add(sql);
            return true;
        }

        public bool Delete<M>(T model, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
        {
            var sql = sqlstring.GetSqlString(model, where);
            li.Add(sql);
            return true;
        }

    }
}
