using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using Developers.ApplicationProgrammingInterface.Properties;

namespace Developers
{
    public partial class FrmCobrar : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public Double totalIVA = 0;
        public Double totalDesc = 0;
        public Double total = 0;
        public Int32 ticket = 0;
        public Double totaldollar = 0;
        public Double totalcambio = 0;

        String ID_Negocio = "";
        String NomComercial = "";
        String NomPropietario = "";
        String Telefono = "";
        String RFC = "";
        String Leyenda = "";
        String DireccionWEB = "";
        String Curp = "";
        String Direccion = "";

        public FrmCobrar()
        {
            InitializeComponent();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Variable.IDClienteActual = 0;
            //Variable.list.Clear();
            this.Close();
        }
        private void cargaImpresora()
        {
            try
            {
                //REVISA
                DataTable tabla = new DataTable();
                String peticion = "SELECT ImpresoraTickets FROM Impresoras WHERE idimpresoras=1";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    Variable.ImpresoraTickets = tabla.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontro la impresora.", "No se encontro la impresora.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        public double consultaTipoCambio()
        {
            Double v=0;
            DataTable tabla = new DataTable();
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd/MM/yyyy");
            string peticion = "SELECT tipoDeCambio FROM tipodecambio WHERE fecha='" + fecha_actual + "'";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peticion, conexion);
                    conexion.Close();
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    v = Convert.ToDouble(tabla.Rows[0][0]);
                    return v;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo conectar verificar la conexion con el servidor " + ex);
            }
            return v;
        }
        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            if (txtPago.Text == "")
            {
                txtPago.Text = "0";
                txtPago.SelectAll();
            }
            if (txtpagod.Text == "")
            {
                txtpagod.Text = "0";
                txtpagod.SelectAll();
            }
                totaldollar = consultaTipoCambio() * (Convert.ToDouble(txtpagod.Text));
                totalcambio = Convert.ToDouble(txtPago.Text)+totaldollar - total;
                txtCambio.Text = String.Format("{0:0.00}", totalcambio);

            if (Convert.ToDouble(txtCambio.Text) >= 0)
                btnCobrar.Enabled = true;
            else
                btnCobrar.Enabled = false;
        }
        private void txtpagod_TextChanged(object sender, EventArgs e)
        {
            if (txtpagod.Text == "")
            {
                txtpagod.Text = "0";
                txtpagod.SelectAll();
            }
            totaldollar = consultaTipoCambio() * (Convert.ToDouble(txtpagod.Text));
            totalcambio = (Convert.ToDouble(txtPago.Text) + totaldollar) - total;
            txtCambio.Text = String.Format("{0:0.00}", totalcambio);

            if (Convert.ToDouble(txtCambio.Text) >= 0)
                btnCobrar.Enabled = true;
            else
                btnCobrar.Enabled = false;
        }
        private void FrmCobrar_Load(object sender, EventArgs e)
        {
            cargaImpresora();
            lblTotal.Text = total.ToString();
            lbldlls.Text = Math.Round(total / Variable.TipoCambio,2).ToString(); 
            txtPago.Text = total.ToString();
        }
        public Double xTotalDesc = 0;
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            btnCobrar.Enabled = false;
            btnCancelar.Enabled = false;
            this.TopMost = false;
            this.Enabled = false;
            //IMPRIME TICKET
            Variable.PagoCon = Convert.ToDouble(txtPago.Text);
            Variable.PagoConUSD = Convert.ToDouble(txtpagod.Text);
            Variable.SuCambio = Convert.ToDouble(txtCambio.Text);
            //////////////////////////////////////////////////////

            GuardaTicket();
            consultaTicketActual();
            insertaEnVentas();
            actualizaExistencias();
            imprimeTicket(Variable.IDTicketActual.ToString());
            
            //RESETEAR PRODUCTO
            Variable.list.Clear();
            Variable.RegresaResetear = 1;
            //////////////////////////////////////////////////////
        }
         
        internal void insertaEnVentas()
        {
            string query = "";
            //MessageBox.Show("inserta en ventas");
            foreach (Producto p in Variable.list)
            {
                xTotalDesc += p.PrecioContado * p.Descuento;
                query = "INSERT into ventas (ID_Ticket,ID_Producto,Descripcion,Precio,Cantidad,SubTotalIVA,SubTotalDescuento,SubTotal,ID_Usuario) values ('" + Variable.IDTicketActual + "','" + p.ID_Producto + "','" + p.Descripcion + "','" + p.PrecioContado + "','" + p.cantidad + "','" + ((p.PrecioContado * p.Impuesto) * p.cantidad) + "','" + ((p.PrecioContado * p.Descuento) * p.cantidad) + "','" + ((p.PrecioContado * p.cantidad) - ((p.PrecioContado * p.Descuento) * p.cantidad)) + "','" + Variable.IDUsuarioActivo + "');";
                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void consultaTicketActual()
        {
            String peticionNT;
            DataTable tabla = new DataTable();
            int v = 0;

            peticionNT = "SELECT ID_Ticket FROM tickets ORDER BY ID_Ticket DESC LIMIT 1 ";
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
                    Variable.IDTicketActual = Convert.ToInt32(tabla.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("No se obtuvo el numero de ticket ");
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
        internal void actualizaExistencias()
        {
            string query = "";
            foreach (Producto p in Variable.list)
            {
                //query = "UPDATE existencias SET existencias = existencias + ('" + p.cantidad + "');";
                query = "Update Productos SET productos.Existencias = productos.Existencias -('" + p.cantidad + "') WHERE productos.ID_Producto='" + p.ID_Producto + "';";
                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public void imprimeTicket(string ticket)
        {
           
                //IMPRIMIR TICKET
                consultaDatosNegocio();
                Ticket Ticket = new Ticket();
                //Ticket.HeaderImage = CargarImagen();
                //ticket.HeaderImage = "C:\imagen.jpg"; //esta propiedad no es obligatoria
                Ticket.AddHeaderLine("        "+NomComercial);
                Ticket.AddHeaderLine("       "+NomPropietario);
                Ticket.AddHeaderLine("         "+RFC);
                Ticket.AddHeaderLine(Direccion);
                //Ticket.AddHeaderLine(Direccion);
                //Ticket.AddHeaderLine("TELEFONO: " + Telefono);
               // Ticket.AddHeaderLine(Leyenda);
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("Ticket No.: " + ticket);
               
                Ticket.AddSubHeaderLine("Le atendio: " + Variable.UsuarioActivo);
                Ticket.AddSubHeaderLine("Fecha: "+DateTime.Now.ToShortDateString() + " Hora: " + DateTime.Now.ToShortTimeString());
                foreach (Producto p in Variable.list)
                {
                    Ticket.AddItem(p.cantidad.ToString(), p.Descripcion.ToString(), (p.PrecioContado*p.cantidad).ToString("c"));
                    Variable.Desc += p.Descuento;
                }
                Ticket.AddTotal("SubTotal:", String.Format("$ {0:0.00}", Variable.xTotal - Variable.xTotaliva));
                Ticket.AddTotal("Descuento:", "-" + String.Format("$ {0:0.00}", xTotalDesc));
                Ticket.AddTotal("IVA:", "+" + String.Format("$ {0:0.00}", Variable.xTotaliva));


                Ticket.AddTotal("TOTAL:", (Variable.xTotal- xTotalDesc).ToString("c"));
                Ticket.AddTotal("","");
                if((txtPago.Text !="0")&&(txtpagod.Text !="0"))
                {
                    Double tempTotal = (Convert.ToDouble(txtPago.Text)+(Convert.ToDouble(txtpagod.Text)* Variable.TipoCambio));
                    Ticket.AddTotal("Pago con Pesos:", String.Format("$ {0:0.00}",Convert.ToDouble(txtPago.Text)));
                    Ticket.AddTotal("Pago con USD:", String.Format("$ {0:0.00}",Convert.ToDouble(txtpagod.Text)));
                    Ticket.AddTotal("....en Pesos:", "(" + String.Format("$ {0:0.00}", Convert.ToDouble(txtpagod.Text) * Variable.TipoCambio) + ")");
                    Ticket.AddTotal("P. Total en Pesos:", String.Format("$ {0:0.00}", tempTotal));
                    Ticket.AddFooterLine("Forma de pago: " + "Efectivo MXN, USD");
                }
                else if(txtPago.Text !="0")
                {                
                    Ticket.AddTotal("Pago con:", String.Format("$ {0:0.00}",Convert.ToDouble(txtPago.Text)));
                    Ticket.AddFooterLine("Forma de pago: " + "Efectivo MXN");
                }
                else if(txtpagod.Text !="0")
                {
                    Ticket.AddTotal("Pago con USD:", String.Format("$ {0:0.00}", Convert.ToDouble(txtpagod.Text)));
                    //Ticket.AddTotal("", "(" + String.Format("$ {0:0.00}", Convert.ToDouble(txtpagod.Text) * consultaTipoCambio()) + ")");
                    Ticket.AddTotal("P. Total en Pesos:", String.Format("$ {0:0.00}", Convert.ToDouble(txtpagod.Text) * consultaTipoCambio()));
                    Ticket.AddFooterLine("Forma de pago: " + "Dollar USD");
                }
                Ticket.AddTotal("Su cambio:", String.Format("$ {0:0.00}", txtCambio.Text));
                Ticket.AddTotal("","");

                Ticket.AddFooterLine("");
                Ticket.AddFooterLine("SON " + enletras(total.ToString()) + " M.N.");
                Ticket.AddFooterLine("");
                Ticket.AddFooterLine("Tipo de cambio USD: " + String.Format("$ {0:0.00}", Variable.TipoCambio));
                Ticket.AddFooterLine("");                
                Ticket.AddFooterLine("      ¡Gracias por su compra!");
                Ticket.PrintTicket(Variable.ImpresoraTickets);
        }
        public void consultaDatosNegocio()
        {
            //CONSULTAR NUMERO DE REGISTROS PARA TICKET ACTUAL
            DataTable tabla = new DataTable();
            string peticion = "SELECT * FROM sucursales WHERE ID_sucursal='"+Variable.IDSucursal+"';";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    ID_Negocio = tabla.Rows[0][0].ToString();
                    NomComercial = tabla.Rows[0][1].ToString();
                    NomPropietario = tabla.Rows[0][2].ToString();
                    Telefono = tabla.Rows[0][3].ToString();
                    RFC = tabla.Rows[0][4].ToString();
                    Leyenda = tabla.Rows[0][5].ToString();
                    DireccionWEB = tabla.Rows[0][6].ToString();
                    Curp = tabla.Rows[0][7].ToString();
                    Direccion = tabla.Rows[0][8].ToString();
                    if (CargarImagen() != null)
                    {
                        CargarImagen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Image BytesAImg(Byte[] ImgBytes)
        {
            //BYTES A IMG
            Bitmap img = null;
            Byte[] bytes = (Byte[])(ImgBytes);
            MemoryStream ms = new MemoryStream(bytes);
            img = new Bitmap(ms);
            return img;
        }
        static Image CargarImagen()
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = "SELECT Imagen FROM sucursales WHERE ID_Sucursal='"+ Variable.IDSucursal +"';";
                    try
                    {
                        byte[] imgArr = (byte[])cmd.ExecuteScalar();
                        using (var stream = new MemoryStream(imgArr))
                        {
                            Image img = Image.FromStream(stream);
                            return img;
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }
        public void GuardaTicket()
        {
            //String connstring;
            String Insert;
            {
                DateTime date1 = DateTime.Now;
                //Console.WriteLine(date1.ToString());

                // Get date-only portion of date, without its time.
                DateTime dateOnly = date1.Date;

                // Display date using short date string.
                //Console.WriteLine(dateOnly.ToString("d"));

                // Display date using 24-hour clock.
                //Console.WriteLine(dateOnly.ToString("g"));

                //Console.WriteLine(dateOnly.ToString("MM/dd/yyyy HH:mm"));
                // The example displays the following output to the console:
                //       6/1/2008 7:47:00 AM
                //       6/1/2008
                //       6/1/2008 12:00 AM
                //       06/01/2008 00:00
                //
                //Console.WriteLine(date1.ToString("%h"));              // Displays 6 
                //Console.WriteLine(date1.ToString("h tt"));            // Displays 6 PM

                Insert = "INSERT into tickets (Corte,Fecha,Hora,Descuento,IVA,Total,PagoMXN,PagoUSD,SuCambio,TipoCambio,ID_Usuario) values (" + (Variable.CorteAbierto) + ",'" + Variable.Fecha + "','" + date1.ToString("hh:mm:ss tt") + "','" + Variable.TotalDesc + "','" + Variable.xTotaliva + "','" + Variable.xTotal + "','" + Variable.PagoCon + "','" + Variable.PagoConUSD + "','" + Variable.SuCambio + "','" + Variable.TipoCambio + "','" + Variable.IDUsuarioActivo + "')";
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        MySqlCommand commando1 = new MySqlCommand(Insert, conexion);
                        //MySqlCommand commando2 = new MySqlCommand(Update, conexion);
                        commando1.ExecuteNonQuery();
                        //commando2.ExecuteNonQuery();
                    }
                    this.DialogResult = DialogResult.OK;  
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtpagod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtpagod.Text.Length; i++)
            {
                if (txtpagod.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtPago.Text.Length; i++)
            {
                if (txtPago.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            Variable.IDClienteActual = 1;
            Variable.FormaPago = "EFECTIVO";
            txtPago.Focus();
        }  
        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }
            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }
        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {
           
            FrmClientes formulario = new FrmClientes();
            //formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            formulario.TopMost = true;
            if ((Variable.IDClienteActual != 0) && (Variable.IDClienteActual != 1))
            {
                Variable.FormaPago = "CREDITO";//a credito
            }
            this.Close();
        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtpagod.Focus();
            }
        }

        private void txtpagod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtpagod.Focus();
                btnCobrar.PerformClick();
            }
        }
    }
}
