using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccess.Model;

namespace DBAccess
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            //for (int i = 0; i < 100000; i++)
            //{
            //    T_Users user = new T_Users();
            //    user.cUsers_Email = "1396510655@qq.com";
            //    user.cUsers_LoginName = "test";
            //    user.cUsers_LoginPwd = "123456";
            //    user.cUsers_Name = "haha";
            //    user.uUsers_ID = Guid.Parse("306de9a2-920f-43a7-aed4-83e6ad7aca61");
            //    user.dUsers_CreateTime = DateTime.Now;
            //}
            T_Users user = new T_Users();
            user.cUsers_Email = "1396510655@qq.com";
            user.cUsers_LoginName = "test";
            user.cUsers_LoginPwd = "123456";
            user.cUsers_Name = "haha";
            user.uUsers_ID = Guid.Parse("306de9a2-920f-43a7-aed4-83e6ad7aca61");
            user.dUsers_CreateTime = DateTime.Now;
            var di = user.fileds;

            Console.WriteLine(" 耗时：" + s.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
