using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Developers
{
    public class ClientesDAL
    {

        internal bool ValidarDatosCliente(int idenviar)
        {
           
            using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conn.Open();
                String query = "SELECT * FROM clientes WHERE ID_Cliente ="+idenviar+" AND Identificador = 0";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return true;
                }
                reader.Close();
                return false;
                
            }
        }
    }
}
