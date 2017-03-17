using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using HZYEntityFrameWork.Entity;

namespace HZYEntityFrameWork.SQLContext
{
    public abstract class AbstractSqlContext<T> : ISqlContext<T> where T : Entity.BaseModel, new()
    {
        // public abstract string GetSqlString(T entity);
        public abstract SQL_Container GetSqlString(MemberInitExpression mie);

        public abstract SQL_Container GetSqlString(MemberInitExpression mie, Expression<Func<T>> where);

        public abstract SQL_Container GetSqlString(MemberInitExpression mie, string where);

    }
}
