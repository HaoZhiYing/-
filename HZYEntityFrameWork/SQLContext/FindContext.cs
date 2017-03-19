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
        Context.EditSqlString<T> sqlstring = new Context.EditSqlString<T>();
        CommitContext commit = new CommitContext();
        public FindContext() { }

    }
}
