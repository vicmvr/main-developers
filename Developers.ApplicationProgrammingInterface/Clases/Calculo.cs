using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace Developers
{
    
    public class Calculo
    {
        internal void calculaAbono(double cantidad, int semanas)
        {
            Double Abono = (cantidad / semanas);
            String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime fechaAux = new DateTime();
            fechaAux = DateTime.Now;
            for (int i = 0; i < semanas; i++)
            {
                try
                {
                    //GUARDA 
                    fechaAux = fechaAux.AddDays(7);
                    String query = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + Variable.IDClienteActual + "','" + fechaHoy + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Abono + "','" + Variable.Saldo + "');";
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }
        internal void calculaAbonoClienteMigrado(int cte,double cantidad, int semanas)
        {
            Double Abono = Math.Ceiling(cantidad / semanas);
            String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime fechaAux = new DateTime();
            fechaAux = DateTime.Now;
            for (int i = 0; i < semanas; i++)
            {
                try
                {
                    //GUARDA 
                    fechaAux = fechaAux.AddDays(7);
                    String query = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + cte + "','" + fechaHoy + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Abono + "','" + cantidad + "');";
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }       
        internal void borraCronograma(int cliente)
        {
            try
            {
                //ACTUALIZA
                String query = "DELETE FROM abonos WHERE ID_Cliente= '" + cliente + "';";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }      
        internal DataTable cargaCronograma(int cliente)
        {
            try
            {
                //REVISA
                DataTable tabla = new DataTable();
                String peticion = "SELECT * FROM abonos WHERE ID_Cliente ='" + cliente + "'";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        return tabla;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return null;
        }
        internal DataTable resumenCredito(string cliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT clientes.Saldo,limitedecredito.CantidadLimite,((limitedecredito.CantidadLimite) - (clientes.Saldo)) AS Disponible,abonos.AbonoSemanal,sum(abonos.Vencido) AS PagosVencidos, case when abonos.Vencido = 1 and abonos.Pagado=0 then (sum(abonos.Vencido) * abonos.AbonoSemanal) - sum(abonos.Abono) else 0 end as CantidadVencida";
                query += " FROM clientes";
                query += " inner join limitedecredito on clientes.LimiteCredito = limitedecredito.ID_Limite";
                query += " inner join abonos on abonos.ID_Cliente = clientes.ID_Cliente";
                query += " where clientes.ID_Cliente =" + cliente + " ";//AND abonos.Vencido=1
                query += " group by clientes.Saldo,limitedecredito.CantidadLimite, ((limitedecredito.CantidadLimite) - (clientes.Saldo)),abonos.AbonoSemanal";
                query += " order by AbonoSemanal desc";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(dt);
                return dt;
            }
        }
        internal DataTable ticketDetalle(string ticket,string idcliente)
        {
            DataTable dt = new DataTable();
            String query = "SELECT ID_Producto,Descripcion,Precio,Cantidad,SubTotal FROM ventascredito WHERE ID_TicketCredito="+ticket+" and ID_Cliente="+idcliente+";";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                //cmd += " FROM clientes";
                //cmd += " inner join limitedecredito on clientes.LimiteCredito = limitedecredito.ID_Limite";
                //cmd += " inner join abonos on abonos.ID_Cliente = clientes.ID_Cliente";
                //cmd += " where clientes.ID_Cliente =" + cliente + " ";
                //cmd += " group by clientes.Saldo,limitedecredito.CantidadLimite, ((limitedecredito.CantidadLimite) - (clientes.Saldo)),abonos.AbonoSemanal";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(dt);
                return dt;
            }
        }
        internal DataTable ObtenerRegs(int idcliente, int numreg)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT ID_Abono FROM abonos where ID_Cliente =" + idcliente + " and pagado = 0 order by ID_Abono asc limit " + numreg + ";";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(dt);
                return dt;
            }
        }
        internal DataTable ObtenerAbonoIncompleto(int idcliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT ID_Abono,Abono FROM abonos where ID_Cliente =" + idcliente + " and pagado = 0 order by ID_Abono asc limit 1";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(dt);
                return dt;
            }
        }
        internal void UpdateAbonos(double abonoSemanal, int idabono, DateTime fhoy)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "UPDATE abonos SET FechaAbonado='" + fhoy.ToString("yyyy-MM-dd HH:mm:ss") + "',Abono=" + abonoSemanal + ",Pagado=" + 1 + " WHERE ID_Abono=" + idabono + ";";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.ExecuteNonQuery();
            }
        }
        internal void actualizaSaldo(int idcliente, double saldo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "UPDATE clientes SET Saldo=" + saldo + " WHERE ID_Cliente=" + idcliente + ";";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        internal int ObtenerUltimoAbono(int idcliente)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT ID_Abono FROM abonos where ID_Cliente =" + idcliente + " order by ID_Abono desc limit 1";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(dt);
                int v = Convert.ToInt32(dt.Rows[0][0]);
                return v;
            }
        }


        internal void calculaUltimoAbono(double UAbono, int idcliente, int IDUltimoAbono)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "UPDATE abonos SET AbonoSemanal='" + UAbono + "' WHERE ID_Cliente=" + idcliente + " AND ID_Abono="+IDUltimoAbono+";";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int IDenviar = 0;
        internal void revisaRango(int idcliente)
        {
            double abonado = 0;
            
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                 conexion.Open();
                String query = "SELECT sum(CantidadAbonada) as abonado FROM abonoshistorial where ID_Cliente = '" + idcliente + "';";
               
                MySqlCommand command = new MySqlCommand(query,conexion);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   abonado = reader.GetDouble("abonado");
                }
                reader.Close();
            }
            
            if ((abonado >= 2500) && (abonado < 4500))
            {
                IDenviar = 4;
            }
            else if ((abonado >= 4500) && (abonado < 6000))
            {
                IDenviar = 3;
            }
            else if ((abonado >= 6000) && (abonado < 8000))
            {
                IDenviar = 2;
            }
            else if (abonado >= 8000)
            {
                IDenviar = 1;
            }
            else
            {
                IDenviar = 0;
            }
            if(IDenviar>0)
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    String query = "UPDATE clientes SET LimiteCredito='" + IDenviar + "' WHERE ID_Cliente=" + idcliente + ";";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public int id;
        internal int ObtenerID(int idcliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT MAX(ID_Abono) AS MaxID FROM abonos WHERE ID_Cliente= '" + idcliente + "';";

                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   id = reader.GetInt32("MaxID");
                }
                reader.Close();
            }
            return id;
        }

        internal void ActualizaUltimoAbPagado(int idcliente, double saldo)
        {
            if (saldo == 0)
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    String query = "UPDATE abonos SET Pagado=1 WHERE ID_Abono=" + ObtenerID(idcliente) + ";";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static bool ValidaCantidad(string id,int cantidad)
        {
            DataTable dt = new DataTable();
            int ct = 0;
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT Existencias AS ex FROM existencias WHERE ID_Producto= '" + id + "' AND ID_Sucursal='"+Variable.IDSucursal+"';";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);
                da.Fill(dt);
            }
                ct = Convert.ToInt32(dt.Rows[0][0]);
                if (ct >= cantidad)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
        internal void insertarSoloUnAbono(int id, double p)
        {
            String fechaHoy = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime fechaAux = new DateTime();
            fechaAux = DateTime.Now;
            fechaAux = fechaAux.AddDays(7);
            String query = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + id + "','" + fechaHoy + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + p + "','" + p + "');";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }

        internal void insertalimite(int id, int idLimite,Double saldo)
        {
            //String query = "UPDATE clientes SET Identificador=1 WHERE ID_Cleinte=" + id + ";";
            String query = "UPDATE clientes SET LimiteCredito='" + idLimite + "', Identificador=1, Saldo="+saldo+" WHERE ID_Cliente='"+id+"';";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }

        internal void calculaAbonoBoletaCapturada(int cte, double cantidad, int semanas, DateTime fecha)
        {
            Double Abono = Math.Ceiling(cantidad / semanas);
            String fechaCap = fecha.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime fechaAux = new DateTime();
            fechaAux = fecha;
            Double ultimoPago = (cantidad - (Abono * (semanas - 1)));
            for (int i = 0; i < (semanas-1); i++)
            {
                try
                {
                    //GUARDA 
                    fechaAux = fechaAux.AddDays(7);
                    String query = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + cte + "','" + fechaCap + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Abono + "','" + cantidad + "');";
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        {
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            if (ultimoPago > 0) { fechaAux = fechaAux.AddDays(7); String query = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + cte + "','" + fechaCap + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + ultimoPago + "','" + cantidad + "');"; using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion())) { conexion.Open(); MySqlCommand cmd = new MySqlCommand(query, conexion); { cmd.ExecuteNonQuery(); cmd.Connection.Close(); } } }
        }

        internal void insCompra(int id, string descripcion, DateTime fecha, double cantidad,double pagonicial)
        {
            try
            {
                //GUARDA 
                String query = "INSERT into ticketscredito (ID_TicketCredito,fecha,Estado,FormaPago,Usuario,TotalTicket,ID_Cliente,ID_Sucursal,ID_Caja,ID_Usuario,PagoInicial) values ('" + consultaTicketCreditoActual().ToString() + "','" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '0' ,'CREDITO','" + Variable.UsuarioActivo + "','" + cantidad + "','" + id + "','" + Variable.IDSucursal + "','" + Variable.IDCaja + "','" + Variable.IDUsuarioActivo + "','" + pagonicial + "');";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    {
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        internal int consultaTicketCreditoActual()
        {
            int valor=0;
            String peticionNT;
            DataTable tabla = new DataTable();
            peticionNT = "SELECT ID_TicketCredito FROM ticketscredito WHERE ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Caja='" + Variable.IDCaja + "' ORDER BY ID_TicketCredito DESC LIMIT 1 ";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticionNT, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    valor = Convert.ToInt32(tabla.Rows[0][0].ToString());
                    return valor;
                }
                else
                {
                    return 1;
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
            return valor;
        }
        internal void insertaEnVentas(int id,string descripcion,double cantidad)
        {
            string query = "";
            //MessageBox.Show("inserta en ventas");
            //foreach (Producto p in Variable.list)
            //{
            query = "INSERT into ventascredito (ID_TicketCredito,Descripcion,SubTotal,ID_Sucursal,ID_Caja,ID_Usuario,ID_Cliente) values ('" + consultaTicketCreditoActual().ToString() + "','" + descripcion + "','" + cantidad + "','" + Variable.IDSucursal + "','" + Variable.IDCaja + "','" + Variable.IDUsuarioActivo + "','" + id + "');";
                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            //}
        }

        public void incrementaNoTicket()
        {
            String Insert;
            {
                Insert = "INSERT into ticketscredito (ID_TicketCredito,estado,ID_Sucursal,ID_caja) values ('" + (consultaTicketCreditoActual() + 1).ToString() + "','" + 1 + "','" + Variable.IDSucursal + "','" + Variable.IDCaja + "');";
                
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        MySqlCommand commando1 = new MySqlCommand(Insert, conexion);
                        commando1.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void insertaSololimite(int id, int idLimite)
        {
            String query = "UPDATE clientes SET LimiteCredito='" + idLimite + "', Identificador=1 WHERE ID_Cliente='" + id + "';";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }

        internal void calculaAbonos(double cantidad,int id)
        {
            int CantSem = 0;
            Double cant = cantidad;
            DataTable tabla = new DataTable();
            String query = "SELECT CantidadLimite,TiempoLimite FROM limitedecredito order by CantidadLimite asc";
             using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                    adaptador.Fill(tabla);
                }
             if (tabla.Rows.Count > 0)
             {
                 foreach (DataRow row in tabla.Rows)
                 {
                     if (cant <= Convert.ToDouble(row["CantidadLimite"]))
                     {
                         CantSem = Convert.ToInt32(row["TiempoLimite"]);
                         cant = 100000000000000000;
                         
                     }
                 }
             }
             //MessageBox.Show(CantSem.ToString());
                   /////////////////////
                    Double Abono = 0;
                    Abono = Math.Ceiling(cantidad / CantSem);
                    if (Abono == 0)
                    {
                        return;
                    }
                    if (Abono < 30)
                    {
                        CantSem = Convert.ToInt32(Math.Ceiling(cantidad / 30));
                        Abono = 30;
                    }

                    DateTime hoy = DateTime.Now;
                    //String fechaCap = fecha.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime fechaAux = new DateTime();
                    fechaAux = hoy;
                    Double ultimoPago = (cantidad - (Abono * (CantSem - 1)));
                    Variable.CtdAbono = Abono;
                    Variable.ProxAbono = hoy.AddDays(7).ToShortDateString();
                    for (int i = 0; i < (CantSem - 1); i++)
                    {
                        try
                        {
                            //GUARDA 
                            fechaAux = fechaAux.AddDays(7);
                            String xquery = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + id + "','" + hoy.ToString("yyyy-MM-dd HH:mm:ss") + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Abono + "','" + cantidad + "');";
                            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                            {
                                conexion.Open();
                                MySqlCommand cmd = new MySqlCommand(xquery, conexion);
                                {
                                    cmd.ExecuteNonQuery();
                                    cmd.Connection.Close();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }
                    }
                    if (ultimoPago > 0) { fechaAux = fechaAux.AddDays(7); String xxquery = "INSERT into abonos (ID_Cliente,FechaInicio,FechaVencimiento,AbonoSemanal,Saldo) values ('" + id + "','" + hoy.ToString("yyyy-MM-dd HH:mm:ss") + "','" + fechaAux.ToString("yyyy-MM-dd HH:mm:ss") + "','" + ultimoPago + "','" + cantidad + "');"; using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion())) { conexion.Open(); MySqlCommand cmd = new MySqlCommand(xxquery, conexion); { cmd.ExecuteNonQuery(); cmd.Connection.Close(); } } }

                    ///////////////////////////
        }
       
        internal void NoAbonos(int idcliente)
        {
            DataTable tabla = new DataTable();
            string query = "SELECT Count(ID_Abono) FROM abonos where ID_Cliente='"+ idcliente +"' AND Pagado=0;";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    Variable.NoAbonos = Convert.ToInt32(tabla.Rows[0][0].ToString());
                }
                else
                {
                    Variable.NoAbonos = 0;
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                Variable.NoAbonos = 0;
            }
        }

        internal DataTable obtenermovimientoscliente(string idcliente)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM abonos where ID_Cliente='" + idcliente + "';";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                adaptador.Fill(dt);
            }
                return dt;
        }

        internal double obtenersaldo(string idcliente)
        {
            double saldo = 0;
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                String query = "SELECT Saldo FROM clientes where ID_Cliente = '" + idcliente + "';";

                MySqlCommand command = new MySqlCommand(query, conexion);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    saldo = reader.GetDouble("Saldo");
                }
                reader.Close();
            }

            return saldo;
        }
    }
}
