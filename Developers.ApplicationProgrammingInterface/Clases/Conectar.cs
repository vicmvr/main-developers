using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Developers
{
    class Conectar
    {

        public static string NuevaConexion()
        {            
            string connectionString =
            "User=SYSDBA;" +
            "Password=MyN1970x;" +
            "Database=" + Application.StartupPath + "\\fdb.fdb;" +
            "DataSource=localhost;" +
            "Port=3050;" +
            "Dialect=3;" +
            "Charset=NONE;" +
            "Role=;" +
            "Connection lifetime=15;" +
            "Pooling=true;" +
            "MinPoolSize=0;" +
            "MaxPoolSize=50;" +
            "Packet Size=8192;" +
            "ServerType=0";
            
            return connectionString;
        }
    }
}


