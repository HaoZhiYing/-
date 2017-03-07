using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using HZYEntityFrameWork.Entity;
using System.Reflection;

namespace HZYEntityFrameWork.Model
{
    public class T_Users : BaseModel
    {
        //uUsers_ID, cUsers_Name, cUsers_LoginName, cUsers_LoginPwd, cUsers_Email, dUsers_CreateTime
        public T_Users()
        {
            this.TableName = "T_Users";
        }

        public Guid? uUsers_ID { get; set; }
        public string cUsers_Name { get; set; }
        public string cUsers_LoginName { get; set; }
        public string cUsers_LoginPwd { get; set; }
        public string cUsers_Email { get; set; }
        public DateTime? dUsers_CreateTime { get; set; }
    }
}
