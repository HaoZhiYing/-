using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Runtime.Remoting.Proxies;

namespace HZYEntityFrameWork.Entity
{
    public class AopEntity : ProxyAttribute
    {
        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            return new AopProxy(serverType).GetTransparentProxy() as MarshalByRefObject;
        }
    }
}
