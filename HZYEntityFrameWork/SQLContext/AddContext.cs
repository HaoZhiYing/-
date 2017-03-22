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
    public class AddContext<T> where T : BaseModel, new()
    {
        Context.AddSqlString<T> add = new Context.AddSqlString<T>();
        CommitContext commit = new CommitContext();
        public AddContext() { }

        private SQL_Container GetSql(T entity)
        {
            var list = new List<MemberBinding>();
            var fileds = entity.EH.GetAllPropertyInfo(entity);
            foreach (var item in fileds) list.Add(Expression.Bind(item, Expression.Constant(item.GetValue(entity), item.PropertyType)));
            return add.GetSqlString(Expression.MemberInit(Expression.New(entity.GetType()), list));
        }

        private dynamic GetModel(T entity)
        {
            string KeyID = string.Empty; dynamic dy = new ExpandoObject();
            var pK = entity.EH.GetPropertyInfo(entity, entity.EH.GetKeyName(entity));//获取主键的 PropertyInfo
            if (pK.PropertyType.Equals(typeof(Guid?)))
            {
                var keyval = Guid.Parse((pK.GetValue(entity) == null ? Guid.Empty : pK.GetValue(entity)).ToString());
                KeyID = keyval == Guid.Empty ? Guid.NewGuid().ToString() : keyval.ToString();
                entity.EH.SetValue(entity, pK.Name, Guid.Parse(KeyID));
            }
            else if (pK.PropertyType.Equals(typeof(int?)))
            {
                //_intid = " SELECT SCOPE_IDENTITY() ";//intID = " SELECT @@IDENTITY ";
            }
            else
                throw new ArgumentException(" 实体中的主键类型不支持 请使用 Guid? 或者 int? 类型 ");
            dy.T = entity; dy.id = KeyID;
            return dy;
        }

        public object Add(T entity)
        {
            var m = this.GetModel(entity);
            var sql = this.GetSql(m.T);
            if (commit.COMMIT(new List<SQL_Container>() { sql }))
                return m.id;
            return null;
        }

        public object Add(T entity, ref List<SQL_Container> li)
        {
            var m = this.GetModel(entity);
            li.Add(this.GetSql(m.T));
            return m.id;
        }

    }
}
