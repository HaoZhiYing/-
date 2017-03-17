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
    /// <summary>
    /// 获取sql字符串接口
    /// </summary>
    public interface ISqlContext<T> where T : Entity.BaseModel, new()
    {
        SQL_Container GetSqlString(MemberInitExpression mie);
        // string GetSqlString(T entity);
    }
}
