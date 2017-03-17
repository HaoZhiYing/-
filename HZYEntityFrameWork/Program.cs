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
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
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
            db.Edit<T_Users>(set => new T_Users()
            {
                cUsers_LoginName = "哈哈我不想说了"
            }, where => where.uUsers_ID == Guid.Parse("306de9a2-920f-43a7-aed4-83e6ad7aca61"));


            Console.WriteLine(" 耗时：" + s.ElapsedMilliseconds);
            Console.ReadKey();
        }

    }
}
