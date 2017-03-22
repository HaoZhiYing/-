using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZYEntityFrameWork.Model
{
    class json
    {
        
public class Rootobject
{
public string total { get; set; }
public string pageSize { get; set; }
public List<Dictionary<string,object>> list { get; set; }
public string currentPage { get; set; }
}

    }
}
