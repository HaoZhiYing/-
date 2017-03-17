using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using HZYEntityFrameWork.Entity;
using HZYEntityFrameWork.SQLContext;

namespace HZYEntityFrameWork
{
    public class DBContext
    {
        protected AddContext<BaseModel> add = new AddContext<BaseModel>();
        public DBContext()
        {
            add = new AddContext<BaseModel>();
        }

        public object Add(BaseModel entity)
        {
            return add.Add(entity);
        }

        public object Add(BaseModel entity, ref List<SQL_Container> li)
        {
            return add.Add(entity, ref li);
        }

    }
}
