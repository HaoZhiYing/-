using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Linq.Expressions;

namespace HZYEntityFrameWork.SQLContext
{
    public class Update
    {
        public Update() { }

        public bool Updates<T>(Expression<Func<T, T>> func)
        {
            var mie = func.Body as MemberInitExpression;
            List<string> member = new List<string>();
            string result = string.Empty;
            foreach (MemberAssignment item in mie.Bindings)
            {
                var eh = ExpressionHelper.ExpressionRouter(item.Expression);
                string update = item.Member.Name + "='" + eh + "' ";
                member.Add(update);

            }
            result = string.Join(",", member);
            return true;
        }


        public string GetConstantStr(ConstantExpression exp)
        {
            object vaule = exp.Value;
            string v_str = string.Empty;
            if (vaule is string)
            {
                v_str = string.Format("'{0}'", vaule.ToString());
            }
            else if (vaule is DateTime)
            {
                DateTime time = (DateTime)vaule; v_str = string.Format("'{0}'", time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                v_str = vaule.ToString();
            }
            return v_str;
        }

    }
}
