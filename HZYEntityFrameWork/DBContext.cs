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
        protected EditContext<BaseModel> edit = new EditContext<BaseModel>();

        public DBContext()
        {
            add = new AddContext<BaseModel>();
            edit = new EditContext<BaseModel>();
        }

        public object Add(BaseModel entity)
        {
            return add.Add(entity);
        }

        public object Add(BaseModel entity, ref List<SQL_Container> li)
        {
            return add.Add(entity, ref li);
        }

        public bool Edit(BaseModel entity)
        {
            return edit.Edit(entity);
        }

        public bool Edit(BaseModel entity, string where)
        {
            return edit.Edit(entity, where);
        }

        public bool Edit(BaseModel entity, BaseModel where)
        {
            return edit.Edit(entity, where);
        }

        public bool Edit<M>(Expression<Func<M, M>> entity, Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            return edit.Edit(entity, where);
        }

        public bool Edit(BaseModel entity, ref List<SQL_Container> li)
        {
            return edit.Edit(entity);
        }

        public bool Edit(BaseModel entity, string where, ref List<SQL_Container> li)
        {
            return edit.Edit(entity, where);
        }

        public bool Edit(BaseModel entity, BaseModel where, ref List<SQL_Container> li)
        {
            return edit.Edit(entity, where);
        }

        public bool Edit<M>(Expression<Func<M, M>> entity, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
        {
            return edit.Edit(entity, where);
        }


    }
}
