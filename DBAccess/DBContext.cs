using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using DBAccess.Entity;
using DBAccess.SQLContext;

namespace HZYEntityFrameWork
{
    public class DBContext
    {
        protected AddContext<BaseModel> add;
        protected EditContext<BaseModel> edit;
        protected DeleteContext<BaseModel> delete;
        protected FindContext<BaseModel> find;

        private string _ConnectionString { get; set; }

        /// <summary>
        /// 默认连接
        /// </summary>
        public DBContext()
        {
            _ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            add = new AddContext<BaseModel>(_ConnectionString);
            edit = new EditContext<BaseModel>(_ConnectionString);
            delete = new DeleteContext<BaseModel>(_ConnectionString);
            find = new FindContext<BaseModel>(_ConnectionString);
        }

        /// <summary>
        /// 自定义连接
        /// </summary>
        /// <param name="ConnectionString">连接串</param>
        public DBContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            add = new AddContext<BaseModel>(_ConnectionString);
            edit = new EditContext<BaseModel>(_ConnectionString);
            delete = new DeleteContext<BaseModel>(_ConnectionString);
            find = new FindContext<BaseModel>(_ConnectionString);
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

        public bool Edit<M>(BaseModel entity, Expression<Func<M, bool>> where) where M : BaseModel, new()
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

        public bool Edit<M>(BaseModel entity, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
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

        public bool Delete<M>(BaseModel entity, Expression<Func<M, bool>> where) where M : BaseModel, new()
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

        public bool Delete<M>(BaseModel entity, Expression<Func<M, bool>> where, ref List<SQL_Container> li) where M : BaseModel, new()
        {
            return delete.Delete(entity, where, ref li);
        }

        public M Find<M>(M entity) where M : BaseModel, new()
        {
            return find.Find(entity);
        }

        public M Find<M>(string where) where M : BaseModel, new()
        {
            return find.Find<M>(where);
        }



        //public M Find<M>(M where, string orderby = "") where M : BaseModel, new()
        //{
        //    return find.Find<M>(where, orderby);
        //}



    }
}
