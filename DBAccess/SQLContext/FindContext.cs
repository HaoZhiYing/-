using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;
using DBAccess.Reflection;
using DBAccess.Entity;
using System.Dynamic;
using System.Data;
using DBAccess.AdoDotNet;

namespace DBAccess.SQLContext
{
    public class FindContext<T> where T : BaseModel, new()
    {
        Context.FindSqlString<T> sqlstring;
        SelectContext select;
        private FindContext() { }

        private string _ConnectionString { get; set; }

        public FindContext(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            select = new SelectContext(_ConnectionString);
            sqlstring = new Context.FindSqlString<T>();
        }

        private SQL_Container GetSql<M>(M entity) where M : BaseModel, new()
        {
            return sqlstring.GetSqlString(entity);
        }

        private SQL_Container GetSql<M>(string where) where M : BaseModel, new()
        {
            return sqlstring.GetSqlString<M>(where);
        }

        private SQL_Container GetSql<M>(Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            return sqlstring.GetSqlString<M>(where);
        }



        public M Find<M>(M entity) where M : BaseModel, new()
        {
            var sql = this.GetSql(entity);
            var dt = select.ExecuteDataset(sql);
            if (dt.Rows.Count == 0)
                return (M)Activator.CreateInstance(entity.GetType());
            return ToModel(dt.Rows[0], (M)Activator.CreateInstance(entity.GetType()));
        }

        public M Find<M>(string where) where M : BaseModel, new()
        {
            var sql = this.GetSql<M>(where);
            var dt = select.ExecuteDataset(sql);
            if (dt.Rows.Count == 0)
                return (M)Activator.CreateInstance(typeof(M));
            return ToModel(dt.Rows[0], (M)Activator.CreateInstance(typeof(M)));
        }

        public M Find<M>(Expression<Func<M, bool>> where) where M : BaseModel, new()
        {
            var sql = this.GetSql<M>(where);
            var dt = select.ExecuteDataset(sql);
            if (dt.Rows.Count == 0)
                return (M)Activator.CreateInstance(typeof(M));
            return ToModel(dt.Rows[0], (M)Activator.CreateInstance(typeof(M)));
        }

        public DataTable Find<M>(M entity, string OrderBy) where M : BaseModel, new()
        {
            sqlstring.OrderBy = OrderBy;
            var sql = this.GetSql(entity);
            return select.ExecuteDataset(sql);
        }

        public List<M> FindToList<M>(M entity, string OrderBy) where M : BaseModel, new()
        {
            sqlstring.OrderBy = OrderBy;
            var sql = this.GetSql(entity);
            var dt = select.ExecuteDataset(sql);
            return this.FindToList<M>(dt);
        }

        public List<M> FindToList<M>(DataTable dt) where M : BaseModel, new()
        {
            return this.ConvertDataTableToList<M>(dt);
        }

        public DataTable Find(string SQL)
        {
            return select.ExecuteDataset(SQL);
        }

        public object FINDToObj(string SQL)
        {
            return SqlHelper.ExecuteScalar(_ConnectionString, CommandType.Text, SQL.ToString());
        }

        public DataTable Find(string SQL, int PageIndex, int PageSize, out int PageCount, out int Counts)
        {
            return select.SysPageList(SQL, PageIndex, PageSize, out PageCount, out Counts);
        }

        public PagingEntity Find(string SQL, int PageIndex, int PageSize)
        {
            int PageCount = 0, Counts = 0;
            var list = new List<Dictionary<string, object>>();
            var dt = this.Find(SQL, PageIndex, PageSize, out PageCount, out Counts);
            var di = new Dictionary<string, object>();
            foreach (DataRow dr in dt.Rows)
            {
                di = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    di.Add(dc.ColumnName, Convert.ChangeType(dr[dc.ColumnName], dc.DataType));
                }
                list.Add(di);
            }
            return new PagingEntity() { List = list.Count > 0 ? list : new List<Dictionary<string, object>>(), dt = dt, PageCount = PageCount, Counts = Counts };
        }


        /// <summary>
        /// 转换实体
        /// </summary>
        /// <param name="r"></param>
        /// <param name="Model"></param>
        /// <returns></returns>
        public T ToModel<T>(DataRow r, T entity) where T : BaseModel
        {
            var list = entity.EH.GetAllPropertyInfo(entity);
            foreach (DataColumn dc in r.Table.Columns)
            {
                var pi = list.Find(item => item.Name.Equals(dc.ColumnName));
                if (pi == null) continue;
                if (!Convert.IsDBNull(r[dc.ColumnName]))
                {
                    if (pi.PropertyType == typeof(Guid?))
                        pi.SetValue(entity, r[dc.ColumnName] as Guid?);
                    else if (pi.PropertyType == typeof(int?))
                        pi.SetValue(entity, r[dc.ColumnName] as int?);
                    else if (pi.PropertyType == typeof(string))
                        pi.SetValue(entity, r[dc.ColumnName] as string);
                    else if (pi.PropertyType == typeof(decimal?))
                        pi.SetValue(entity, r[dc.ColumnName] as decimal?);
                    else if (pi.PropertyType == typeof(double?))
                        pi.SetValue(entity, r[dc.ColumnName] as double?);
                    else if (pi.PropertyType == typeof(float?))
                        pi.SetValue(entity, r[dc.ColumnName] as float?);
                    else if (pi.PropertyType == typeof(DateTime?))
                        pi.SetValue(entity, r[dc.ColumnName] as DateTime?);
                    else if (pi.PropertyType == typeof(bool?))
                        pi.SetValue(entity, r[dc.ColumnName] as bool?);
                    else
                        throw new Exception("FindContext,的 ToModel 函数 暂不支持该类型" + pi.PropertyType + " !");
                }
            }
            return entity;
        }

        /// <summary>
        /// 将datatable转换为list<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<T> ConvertDataTableToList<T>(DataTable table)
        {
            List<T> list = new List<T>();
            Type typeInfo = typeof(T);
            //得到T内所有的公共属性
            var propertys = typeInfo.GetProperties().ToList();
            foreach (DataRow rowItem in table.Rows)
            {
                //通过反射动态创建对象
                T objT = Activator.CreateInstance<T>();
                //给objT的所有属性赋值
                foreach (DataColumn columnItem in table.Columns)
                {
                    //获取指定单元格的值
                    object value = rowItem[columnItem.ColumnName];
                    if (!Convert.IsDBNull(value))
                    {
                        var pi = propertys.Find(item => item.Name.ToLower() == columnItem.ColumnName.ToLower());

                        if (pi.PropertyType == typeof(Guid?))
                            pi.SetValue(objT, value as Guid?);
                        else if (pi.PropertyType == typeof(int?))
                            pi.SetValue(objT, value as int?);
                        else if (pi.PropertyType == typeof(string))
                            pi.SetValue(objT, value as string);
                        else if (pi.PropertyType == typeof(decimal?))
                            pi.SetValue(objT, value as decimal?);
                        else if (pi.PropertyType == typeof(double?))
                            pi.SetValue(objT, value as double?);
                        else if (pi.PropertyType == typeof(float?))
                            pi.SetValue(objT, value as float?);
                        else if (pi.PropertyType == typeof(DateTime?))
                            pi.SetValue(objT, value as DateTime?);
                        else if (pi.PropertyType == typeof(bool?))
                            pi.SetValue(objT, value as bool?);
                        else
                            throw new Exception("FindContext,的 ConvertDataTableToList 函数 暂不支持该类型" + pi.PropertyType + " !");
                    }
                }
                list.Add(objT);
            }
            return list;
        }

    }
}
