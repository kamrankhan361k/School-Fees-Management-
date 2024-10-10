using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.DataAccess
{
    public abstract class ConnectionAccess
    {
        protected string Year
        {
            get;
            set;
        }

        protected string ConnectionString
        {
            get
            {
                if (ConfigurationManager.AppSettings.Get("IsDefault") == "true")
                {
                    return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\School_" + Year + ".accdb;Jet OLEDB:Database Password=arity@123;";
                }
                else
                {
                    return ConfigurationManager
                   .ConnectionStrings["School_ConnectionString"]
                   .ToString();
                }
            }
        }

        protected string ConnectionStringMaster
        {
            get
            {
                if (ConfigurationManager.AppSettings.Get("IsDefault") == "true")
                {
                    return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\School_Master.accdb;Jet OLEDB:Database Password=arity@123;";
                }
                else
                {
                    return ConfigurationManager
                   .ConnectionStrings["School_Master_ConnectionString"]
                   .ToString();
                }

            }
        }
    }
}
