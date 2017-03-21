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
        protected DeleteContext<BaseModel> delete = new DeleteContext<BaseModel>();
        protected FindContext<BaseModel> find = new FindContext<BaseModel>();

        public DBContext()
        {
            add = new AddContext<BaseModel>();
            edit = new EditContext<BaseModel>();
            delete = new DeleteContext<BaseModel>();
            find = new FindContext<BaseModel>();
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
            return edit.Edit(entity, ref li);
        }

        public bool Edit(BaseModel entity, string where, ref List<SQL_Container> li)
        {
            return edit.Edit(entity, where, ref li);
        }

        public bool Edit(BaseModel entity, BaseModel where, ref List<SQL_Container> li)
        {
            return edit.Edit(entity, where, ref li);
        }

        public bool Edit<M>(Expression<Func<M, M>> entity, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
        {
            return edit.Edit(entity, where, ref li);
        }

        public bool Delete(BaseModel entity)
        {
            return delete.Delete(entity);
        }

        public bool Delete(BaseModel entity, string where)
        {
            return delete.Delete(entity, where);
        }

        public bool Delete(BaseModel entity, BaseModel where)
        {
            return delete.Delete(entity, where);
        }

        public bool Delete<M>(Expression<Func<M, M>> entity, Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            return delete.Delete(entity, where);
        }

        public bool Delete(BaseModel entity, ref List<SQL_Container> li)
        {
            return delete.Delete(entity, ref li);
        }

        public bool Delete(BaseModel entity, string where, ref List<SQL_Container> li)
        {
            return delete.Delete(entity, where, ref li);
        }

        public bool Delete(BaseModel entity, BaseModel where, ref List<SQL_Container> li)
        {
            return delete.Delete(entity, where, ref li);
        }

        public bool Delete<M>(Expression<Func<M, M>> entity, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
        {
            return delete.Delete(entity, where, ref li);
        }

        public M Find<M>(M where, string orderby = "") where M : BaseModel, new()
        {
            return find.Find<M>(where, orderby);
        }



    }
}
