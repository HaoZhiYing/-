﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using HZYEntityFrameWork.Model;
using HZYEntityFrameWork.Reflection;

namespace HZYEntityFrameWork
{
    using System.Diagnostics;
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            T_Users tu = new T_Users();
            tu.cUsers_Email = "123";
            tu.cUsers_LoginName = "444444444";
            tu.cUsers_LoginPwd = "12311231";
            tu.cUsers_Name = "hhhhhhhh";
            tu.dUsers_CreateTime = DateTime.Now;
           
            string str = string.Empty;
            Type t = tu.GetType();
            var list = BaseHelper.GetAllPropertyInfo(t);
            list.ForEach(item =>
            {
                BaseHelper.SetValue(tu, "cUsers_Email", "傻逼呀");
                //item.SetValue(t, null)
                str += "-------" + item.Name + "=" + BaseHelper.GetValue(tu, item.Name) + "\r\n";
            });
            s.Stop();
            Console.WriteLine(str + " 耗时：" + s.ElapsedTicks);
            Console.ReadKey();

        }
    }
}
