using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using HZYEntityFrameWork.AdoDotNet;
using HZYEntityFrameWork.Entity;

namespace HZYEntityFrameWork.SQLContext
{
    public class CommitContext
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="li"></param>
        /// <returns></returns>
        public bool COMMIT(List<SQL_Container> li)
        {
            using (SqlConnection conn = new SqlConnection(SqlHelper.getConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    li.ForEach(item =>
                    {
                        cmd.Parameters.Clear();
                        //执行sql
                        cmd.CommandText = item._SQL;
                        item._SQL_Parameter.ToList().ForEach(p =>
                        {
                            cmd.Parameters.Add(p);
                        });
                        cmd.ExecuteNonQuery();
                    });
                    //提交事务
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    //失败则回滚事务
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
