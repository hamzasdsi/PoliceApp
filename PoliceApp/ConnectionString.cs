using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceApp
{
    class ConnectionString
    {
        public string DBConn()
        {
            //string str = "Data Source=DESKTOP-GITRNUG;initial Catalog=DBpolice;User ID=sa;Password=sdsi*2017; MultipleActiveResultSets=True";
            string str = "Data Source=192.168.70.182;initial Catalog=DBpolice;User ID=sa;Password=sdsi*2018";
            return str;
        }
    }
}
