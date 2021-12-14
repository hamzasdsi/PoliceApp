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
            //string str = @"Data Source=DESKTOP-I30GQMS\SQLSERVER2014;initial Catalog=DBpolice;Integrated security=true";
            string str = @"Data Source=192.168.70.34;initial Catalog=DBpolice;User ID=sa;Password=sdsi*2022"; 
            //string str = "Data Source=192.168.70.182;initial Catalog=DBpolice;User ID=sa;Password=sdsi*2018";
            //string str = @"Data Source=DESKTOP-O323VT7;initial Catalog=DBpolice;Integrated security=true";
            return str;
        }
    }
}
