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

        public M Find<M>(M entity) where M : BaseModel, new()
        {
            sqlstring.w
            return null;
        }
    }
}
