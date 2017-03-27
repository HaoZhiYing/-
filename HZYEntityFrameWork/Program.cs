using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using HZYEntityFrameWork.SQLContext;
using HZYEntityFrameWork.Model;
using HZYEntityFrameWork.Reflection;
using System.Linq.Expressions;

namespace HZYEntityFrameWork
{
    using System.Diagnostics;
    using System.Web.Script.Serialization;
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < 1; i++)
            {
                DBContext db = new DBContext();
                T_Users user = new T_Users();
                user.cUsers_Email = "1396510655@qq.com";
                user.cUsers_LoginName = "test";
                user.cUsers_LoginPwd = "123456";
                user.cUsers_Name = "haha";
                user.uUsers_ID = Guid.Parse("306de9a2-920f-43a7-aed4-83e6ad7aca61");
                user.dUsers_CreateTime = DateTime.Now;
                //var key = db.Add(user);
                //db.Edit(user);
                //db.Edit(set=>new T_Users(){},where=>where.);
                if (db.Edit<T_Users>(set => new T_Users()
                   {
                       cUsers_LoginName = "哈哈我不想说了",
                       dUsers_CreateTime = null
                   }, where => where.uUsers_ID == Guid.Parse("306de9a2-920f-43a7-aed4-83e6ad7aca61")
                   && where.cUsers_Email.Contains("aa")
                   && where.cUsers_Email != Guid.NewGuid().ToString()))
                {

                }

                //db.Edit(user);
                user = new T_Users();
                user.uUsers_ID = Guid.Parse("306de9a2-920f-43a7-aed4-83e6ad7aca61");
                var model = db.Find(user);
            }

            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic dy = jss.Deserialize<dynamic>(@"{
    'total': '2',
    'pageSize': '20',
    'list': {rows:[{'channel':'lzyq88','customer_id':'104607'}]},
    'currentPage': '1'
}");

            Console.WriteLine(" 耗时：" + s.ElapsedMilliseconds);
            Console.ReadKey();
        }

    }
}
