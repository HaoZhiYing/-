using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Linq.Expressions;
using DBAccess.Entity;
using DBAccess.ExpressionTree;

namespace DBAccess.SQLContext
{
    public abstract class AbstractSqlContext<T> : ISqlContext<T> where T : Entity.BaseModel, new()
    {
        public abstract SQL_Container GetSqlString(T entity);
    }
}
