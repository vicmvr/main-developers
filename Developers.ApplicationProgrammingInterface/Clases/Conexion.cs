using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Developers
{
    class Conexion
    {
        public enum Mododeacceso
        {
            indefinido,
            Firebird,
            Odbc,
            MySql,
            Npgsql,
            MSSql,
            SQLite,
            Oracle,
        }
        public static DbConnection Nueva()
        {

            //
            int conxn = 1;
            String ProveedorSeleccionado = "Firebird";
            string Proveedor = "";
            switch (conxn)
            {
                default:
                    Proveedor = "Firebird";
                    return ConexionFirebird();
                case 1:
                    Proveedor = "MariaDB/MySQL";
                    return ConexionMySQL();
                case 2:
                    Proveedor = "SQL Server";
                    return ConexionSQLServer();
                //case 3:
                //    Proveedor = "PostgreSQL";
                //    return ConexionPostgreSQL();
                //case 4:
                //    Proveedor = "Oracle";
                //    return ConexionOracle();
                //case 5:
                //    Proveedor = "SQLite";
                //    return ConexionSQLite();
            }
        }

        

        public static FbConnection ConexionFirebird()
        {
            string connectionString =
            "User=SYSDBA;" +            "Password=MyN1970x;" +
            "Database=" + Application.StartupPath + "\\fdb.fdb;" +            "DataSource=localhost;" +
            "Port=3050;" +            "Dialect=3;" +
            "Charset=NONE;" +            "Role=;" +
            "Connection lifetime=15;" +            "Pooling=true;" +
            "MinPoolSize=0;" +            "MaxPoolSize=50;" +
            "Packet Size=8192;" +            "ServerType=0";
            //return connectionString;
            

            FbConnection conexion = new FbConnection(connectionString);
            return conexion;

        }
        public static MySqlConnection ConexionMySQL()
        {
            String connstring;
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
            MySqlConnection conexion = new MySqlConnection(connstring);
            return conexion;
        }
        private static SqlConnection ConexionSQLServer()
        {
            SqlConnection conexion = new SqlConnection(@"integrated security=true;initial catalog = ventas; data source=localhost\SQLEXPRESS");


            return conexion;
        }
        private static string ConexionSQLite()
        {
            throw new NotImplementedException();
        }

        private static string ConexionOracle()
        {
            throw new NotImplementedException();
        }

        private static string ConexionPostgreSQL()
        {
            throw new NotImplementedException();
        }
        public static string NuevaConexion()
        {
            throw new NotImplementedException();
        }
    }
}
