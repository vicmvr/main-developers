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
    public partial class FrmHistorialVentas : Form
    {
        public Double totalIVA = 0;
        public Double totalDesc = 0;
        public Double total = 0;
        public Int32 ticket = 0;

        public Double totaldollar = 0;
        public Double totalcambio = 0;

        public string cajid;
        public string sucid;
        public string tipov;
        int estado;
        public string IDTicket { get; set; }
        public DataTable dt = new DataTable();
        ///
        int cte = 0;
        int idVenta = 0;
        string idProducto = "";
        int idSucursal = 0;
        int cantidad = 0;
        double subtotal = 0;

        public FrmHistorialVentas()
        {
            InitializeComponent();
        }
        private void txtTicket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnBuscar.PerformClick();
            }  
        }
        private void FrmHistorialVentas_Load(object sender, EventArgs e)
        {
            cargaCajeros();
            cbTipo.SelectedIndex = 0;
        }
        private void cargaCajeros()
        {
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                String query;
                cnn.Open();
                query = "select Nombre,ID_Usuario,ID_Sucursal from usuarios WHERE Rol='CAJERO' or Rol='SUPERVISOR';";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, cnn);
                adaptador.Fill(dt);
                cbCajero.DataSource = dt;
                cbCajero.DisplayMember = "Nombre";
                cbCajero.ValueMember = "ID_Usuario";
                cbCajero.SelectedIndex = 0;
                cajid = cbCajero.SelectedValue.ToString();
                sucid = dt.Rows[cbCajero.SelectedIndex][2].ToString();
            }
            
        }
        public string query;
        private void cargarTickets()
        {
            DataTable tablatickets = new DataTable();
            tablatickets.Clear();
            
            btnCancelarProd.Enabled = false;
            btnCancelarTicket.Enabled = false;
            //lblCancelado.Visible = false;
            if (tipov == "CONTADO")
            {
                //query = "SELECT ID_Ticket,Fecha,Hora,CorteTicket,TotalTicket,Usuario,Estado FROM tickets WHERE fecha BETWEEN '" + Convert.ToDateTime(dtDesde.Text) + "' AND '" + Convert.ToDateTime(dtHasta.Text) + "' AND (Estado!='" + 1 + "'AND ID_Usuario='" + cajid + "');";
                query = "SELECT ID_Ticket,Fecha,Hora,CorteTicket,TotalTicket,Usuario,Estado FROM tickets WHERE Fecha = '" + dtDesde.Text + "' AND Estado!='" + 1 + "'AND ID_Usuario='" + cajid + "';";
            }
            else
            {
                //query = "SELECT ID_TicketCredito,Fecha,Hora,Corte,TotalTicket,Usuario,Estado,ID_Cliente FROM ticketscredito WHERE fecha BETWEEN '" + dtDesde.Text + "' AND '" + dtHasta.Text + "' AND Estado!='" + 1 + "'AND ID_Usuario='" + cajid + "';";
                query = "SELECT ID_TicketCredito,Fecha,Hora,Corte,TotalTicket,Usuario,Estado,ID_Cliente FROM ticketscredito WHERE Fecha = '" + dtDesde.Text + "' AND Estado!='" + 1 + "'AND ID_Usuario='" + cajid + "';";
            }
          
                using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(tablatickets);
                }
                //Rellenamos tabla
                if (tablatickets.Rows.Count > 0)
                {
                    lblNumTickets.Text = tablatickets.Rows.Count.ToString();
                    double totalIngresos = 0;
                    for (int i = 0; i < tablatickets.Rows.Count; i++)
                    {
                        totalIngresos = totalIngresos + Convert.ToDouble(tablatickets.Rows[i][4]);
                    }
                    lblTotalIngresos.Text = String.Format("$ {0:0.00}", totalIngresos);
                }
                else
                {
                    lblNumTickets.Text = "$ 00.00";
                    lblTotalIngresos.Text = "$ 00.00";
                }
                ////
                dataGridView2.DataSource = null;
                lblTotalTicket.Text = "$ 00.00";
                dataGridView1.DataSource = tablatickets;

                //dataGridView1.Columns["ID_Venta"].Visible = false;
                dataGridView1.Columns["Fecha"].Visible = true;
                dataGridView1.Columns["Hora"].Visible = false;
                dataGridView1.Columns["Usuario"].Visible = false;
                dataGridView1.Columns["Estado"].Visible = false;
                
                if (tipov == "CONTADO")
                {
                    dataGridView1.Columns["ID_Ticket"].HeaderText = "# Ticket";
                    dataGridView1.Columns["ID_Ticket"].Width = 60;
                    dataGridView1.Columns["CorteTicket"].HeaderText = "# Corte"; 
                    dataGridView1.Columns["CorteTicket"].Width = 60;
                }
                else
                {
                    dataGridView1.Columns["ID_Cliente"].Visible = false;
                    dataGridView1.Columns["ID_TicketCredito"].HeaderText = "# Ticket";
                    dataGridView1.Columns["ID_TicketCredito"].Width = 60;
                    dataGridView1.Columns["Corte"].HeaderText = "# Corte";
                    dataGridView1.Columns["Corte"].Width = 60;
                }
                dataGridView1.Columns["TotalTicket"].HeaderText = "Total";
                dataGridView1.Columns["TotalTicket"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
               // cte = Convert.ToInt32(dataGridView1.Rows[0].Cells["ID_Cliente"].Value);
                dataGridView1.ClearSelection();
                int cont = 0;
                foreach (DataGridViewRow dg in dataGridView1.Rows)
                {
                    try
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[cont].Cells["Estado"].Value) == 2)
                        {
                            dataGridView1.Rows[cont].DefaultCellStyle.BackColor = Color.Bisque;
                        }
                        cont++;
                    }
                    catch (Exception r)
                    {
                    }
                }
                txtTicket.Focus();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.CurrentCell != null)
            {
                btnCancelarProd.Enabled = false;
                if (Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value) == 0)
                {
                    btnCancelarTicket.Enabled = true;
                }
                else
                {
                    btnCancelarTicket.Enabled = false;
                }
                IDTicket = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (tipov == "CREDITO")
                {
                    cte = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[7].Value);
                }
                //estado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value);
                //if (estado == 2)
                //{
                //    lblCancelado.Visible = true;
                //}
                //else
                //{
                //    lblCancelado.Visible = false;
                //}
                lblTicketTitulo.Text = "Detalles del ticket # " + IDTicket;
                txtTicket.Text = IDTicket;
                button1.PerformClick();
            }
        }
        private void cargarArticulos(string Ticket)
        {
            DataTable tablaarticulos = new DataTable();
            tablaarticulos.Clear();
            string query;
            if (tipov == "CONTADO")
            {
                query = "SELECT * FROM ventas WHERE ID_Ticket='" + Ticket + "' AND ID_Usuario='" + cajid + "';";
            }
            else
            {
                query = "SELECT * FROM ventascredito WHERE ID_TicketCredito='" + Ticket + "' AND ID_Usuario='" + cajid + "';";
            }
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                adaptador.Fill(tablaarticulos);
            }
                if (tablaarticulos.Rows.Count > 0)
                {
                    double totalTicket = 0;
                    double totalProductos = 0;
                   
                    for (int i = 0; i < tablaarticulos.Rows.Count; i++)
                    {
                        if (tipov == "CONTADO")
                        {
                            if (Convert.ToInt32(tablaarticulos.Rows[i][12]) != 2)
                            {
                                totalTicket = totalTicket + Convert.ToDouble(tablaarticulos.Rows[i][8]);
                                totalProductos = totalProductos + Convert.ToDouble(tablaarticulos.Rows[i][5]);
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(tablaarticulos.Rows[i][12]) != 2)
                            {
                                totalTicket = totalTicket + Convert.ToDouble(tablaarticulos.Rows[i][7]);
                                totalProductos = totalProductos + Convert.ToDouble(tablaarticulos.Rows[i][5]);
                            }
                        }
                    }
                    lblTotalTicket.Text = String.Format("$ {0:0.00}", totalTicket);
                    lblNumProductos.Text = totalProductos.ToString();
                    lblTicketTitulo.Text = "Detalles del ticket # " + txtTicket.Text;
                }
                else 
                { 
                    txtTicket.SelectAll();
                    txtTicket.Focus();
                }
                dataGridView2.DataSource = tablaarticulos;
                if (tipov == "CONTADO")
                {
                    dataGridView2.Columns["ID_Venta"].Visible = false;
                    dataGridView2.Columns["ID_Ticket"].Visible = false;
                    dataGridView2.Columns["Estado"].Visible = false;
                }
                else
                {
                    dataGridView2.Columns["ID_Venta"].Visible = false;
                    dataGridView2.Columns["ID_TicketCredito"].Visible = false;
                    dataGridView2.Columns["Estado"].Visible = false;
                }
                dataGridView2.Columns["ID_Producto"].Visible = false;
                //dataGridView2.Columns["ID_Cliente"].Visible = false;
                dataGridView2.Columns["ID_Sucursal"].Visible = false;
                dataGridView2.Columns["ID_Caja"].Visible = false;
                dataGridView2.Columns["ID_Usuario"].Visible = false;
                //dataGridView2.Columns["ID"].Visible = false;


                dataGridView2.Columns["Descripcion"].HeaderText = "Descripción";
                dataGridView2.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView2.Columns["Precio"].DefaultCellStyle.Format = "c";
                //dataGridView2.Columns["Precio"].DefaultCellStyle.BackColor = Color.Bisque;
                dataGridView2.Columns["Precio"].Width = 65;

                dataGridView2.Columns["Cantidad"].DefaultCellStyle.Format = "n";
                //dataGridView2.Columns["Cantidad"].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView2.Columns["Cantidad"].Width = 65;

                dataGridView2.Columns["SubTotalIVA"].HeaderText = "IVA";
                dataGridView2.Columns["SubTotalIVA"].DefaultCellStyle.Format = "n";
                //dataGridView2.Columns["IVA"].DefaultCellStyle.BackColor = Color.Azure;
                dataGridView2.Columns["SubTotalIVA"].Width = 65;

                if (tipov == "CONTADO")
                {
                    dataGridView2.Columns["SubTotalDescuento"].HeaderText = "Desc";
                    dataGridView2.Columns["SubTotalDescuento"].DefaultCellStyle.Format = "c";
                    dataGridView2.Columns["SubTotalDescuento"].Width = 65;
                }
                dataGridView2.Columns["Subtotal"].DefaultCellStyle.Format = "c";
                //dataGridView1.Columns["Subtotal"].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView2.Columns["Subtotal"].Width = 65;

                dataGridView2.ClearSelection();
                int cont = 0;
                foreach (DataGridViewRow dg in dataGridView2.Rows)
                {
                    try
                    {
                        if (Convert.ToInt32(dataGridView2.Rows[dg.Index].Cells["Estado"].Value) == 2)
                        {
                            dataGridView2.Rows[cont].DefaultCellStyle.BackColor = Color.Bisque;
                        }
                        cont++;
                    }catch(Exception r)
                    {
                    }
                }
                txtTicket.Focus();
            
        }
        private void cargarArticulos(string IDTicket, string p)
        {
            //cargaIDCajero();
            DataTable tablaarticulos = new DataTable();
            tablaarticulos.Clear();
            string query = "SELECT * FROM ventas WHERE ID_Ticket='" + IDTicket + "' AND ID_Sucursal='" + p + "' AND ID_Usuario='" + cajid + "';";

            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, conexion);
                adaptador.Fill(tablaarticulos);
            }
            if (tablaarticulos.Rows.Count > 0)
            {
                double totalTicket = 0;
                double totalProductos = 0;
                for (int i = 0; i < tablaarticulos.Rows.Count; i++)
                {
                    totalTicket = totalTicket + Convert.ToDouble(tablaarticulos.Rows[i][8]);
                    totalProductos = totalProductos + Convert.ToDouble(tablaarticulos.Rows[i][5]);
                }
                lblTotalTicket.Text = String.Format("$ {0:0.00}", totalTicket);
                lblNumProductos.Text = totalProductos.ToString();
                lblTicketTitulo.Text = "Detalles del ticket # " + txtTicket.Text;
            }
            else
            {
                txtTicket.SelectAll();
                txtTicket.Focus();
            }
            ////
            dataGridView2.DataSource = tablaarticulos;

            dataGridView2.Columns["ID_Venta"].Visible = false;
            dataGridView2.Columns["ID_Ticket"].Visible = false;
            dataGridView2.Columns["ID_Producto"].Visible = false;
            //dataGridView2.Columns["ID_Cliente"].Visible = false;
            dataGridView2.Columns["ID_Sucursal"].Visible = false;
            dataGridView2.Columns["ID_Caja"].Visible = false;
            dataGridView2.Columns["ID_Usuario"].Visible = false;
            //dataGridView2.Columns["ID"].Visible = false;



            dataGridView2.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridView2.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView2.Columns["Precio"].DefaultCellStyle.Format = "c";
            //dataGridView2.Columns["Precio"].DefaultCellStyle.BackColor = Color.Bisque;
            dataGridView2.Columns["Precio"].Width = 65;

            dataGridView2.Columns["Cantidad"].DefaultCellStyle.Format = "n";
            //dataGridView2.Columns["Cantidad"].DefaultCellStyle.BackColor = Color.Beige;
            dataGridView2.Columns["Cantidad"].Width = 65;

            dataGridView2.Columns["SubTotalIVA"].HeaderText = "IVA";
            dataGridView2.Columns["SubTotalIVA"].DefaultCellStyle.Format = "n";
            //dataGridView2.Columns["IVA"].DefaultCellStyle.BackColor = Color.Azure;
            dataGridView2.Columns["SubTotalIVA"].Width = 65;

            dataGridView2.Columns["SubTotalDescuento"].HeaderText = "Desc";
            dataGridView2.Columns["SubTotalDescuento"].DefaultCellStyle.Format = "c";
            dataGridView2.Columns["SubTotalDescuento"].Width = 65;

            dataGridView2.Columns["Subtotal"].DefaultCellStyle.Format = "c";
            //dataGridView1.Columns["Subtotal"].DefaultCellStyle.BackColor = Color.Beige;
            dataGridView2.Columns["Subtotal"].Width = 65;

            dataGridView2.ClearSelection();
            txtTicket.Focus();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IDTicket = txtTicket.Text;
            cargaTicket(txtTicket.Text);
            cargarArticulos(IDTicket);
            
            //txtTicket.Clear();
        }
        private void cargaTicket(string p)
        {

            DataTable tablatickets = new DataTable();
            tablatickets.Clear();
            string query;
            if (tipov == "CONTADO")
            {
                query = "SELECT ID_Ticket,Fecha,Hora,CorteTicket,TotalTicket,Usuario,Estado FROM tickets WHERE ID_Ticket='" + p + "' AND ID_USuario='" + cajid + "'";
            }
            else
            {
                query = "SELECT ID_TicketCredito,Fecha,Hora,Corte,TotalTicket,Usuario,Estado,ID_Cliente FROM ticketscredito WHERE ID_TicketCredito='" + p + "' AND ID_USuario='" + cajid + "'";
            }

            using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(tablatickets);
            }
            //Rellenamos tabla
            if (tablatickets.Rows.Count > 0)
            {
            //    estado = Convert.ToInt32(tablatickets.Rows[0][6]);
            //if (estado == 2)
            //{
            //    lblCancelado.Visible = true;
            //}
            //else
            //{
            //    lblCancelado.Visible = false;
            //}
                lblNumTickets.Text = tablatickets.Rows.Count.ToString();
                double totalIngresos = 0;
                for (int i = 0; i < tablatickets.Rows.Count; i++)
                {
                    totalIngresos = totalIngresos + Convert.ToDouble(tablatickets.Rows[i][4]);
                }
                lblTotalIngresos.Text = String.Format("$ {0:0.00}", totalIngresos);
            }
            else
            {
                lblNumTickets.Text = "$ 00.00";
                lblTotalIngresos.Text = "$ 00.00";
            }
            ////
            dataGridView2.DataSource = null;
            lblTotalTicket.Text = "$ 00.00";
            dataGridView1.DataSource = tablatickets;

            //dataGridView1.Columns["ID_Venta"].Visible = false;
            dataGridView1.Columns["Fecha"].Visible = true;
            dataGridView1.Columns["Hora"].Visible = false;
            dataGridView1.Columns["Usuario"].Visible = false;

            if (tipov == "CONTADO")
            {
                dataGridView1.Columns["ID_Ticket"].HeaderText = "# Ticket";
                dataGridView1.Columns["ID_Ticket"].Width = 60;

                dataGridView1.Columns["CorteTicket"].HeaderText = "# Corte";
                dataGridView1.Columns["CorteTicket"].Width = 60;
            }
            else
            {

                dataGridView1.Columns["ID_Cliente"].Visible = false;
                dataGridView1.Columns["ID_TicketCredito"].HeaderText = "# Ticket";
                dataGridView1.Columns["ID_TicketCredito"].Width = 60;

                dataGridView1.Columns["Corte"].HeaderText = "# Corte";
                dataGridView1.Columns["Corte"].Width = 60;
            }
            dataGridView1.Columns["TotalTicket"].HeaderText = "Total";
            dataGridView1.Columns["TotalTicket"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.ClearSelection();
            txtTicket.Focus();

        }
        private void btnBuscarT_Click(object sender, EventArgs e)
        {
            cargarTickets();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IDTicket == string.Empty)
            { MessageBox.Show("Por favor seleccione un ticket"); }
            else
            {
                cargarArticulos(IDTicket);
            }
        }
        private void cbCajero_SelectedIndexChanged(object sender, EventArgs e)
        {
            cajid = cbCajero.SelectedValue.ToString();
            sucid = dt.Rows[cbCajero.SelectedIndex][2].ToString();
            tipov = cbTipo.Text;
            cargarTickets();
            
            btnCancelarProd.Enabled = false;
            btnCancelarTicket.Enabled = false;
        }
        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            cargarTickets();
        }
        private void dtHasta_ValueChanged(object sender, EventArgs e)
        {
            cargarTickets();
        }
        private void btnCancelarTicket_Click(object sender, EventArgs e)
        {
            if (txtComentarios.Text == String.Empty)
            {
                MessageBox.Show("Por favor ingrese un comentario antes de cancelar");
                return;
            }
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                string query;
                if (Convert.ToInt32(IDTicket) > 0)
                {
                    if (tipov == "CONTADO")
                    {
                        query = "UPDATE tickets SET Estado=2,comentarios='"+txtComentarios.Text+"' WHERE ID_Ticket=" + IDTicket + " AND ID_Sucursal=" + sucid + " AND ID_Usuario=" + cajid + ";";
                        cancelaventas(IDTicket,sucid,cajid);
                        txtComentarios.Clear();
                        
                    }
                    else
                    {
                        query = "UPDATE ticketscredito SET Estado=2, comentarios='" + txtComentarios.Text + "' WHERE ID_TicketCredito=" + IDTicket + " AND ID_Sucursal=" + sucid + " AND ID_Usuario=" + cajid + ";";
                        cancelaventas(IDTicket, sucid, cajid);    
                        actualizaSaldo(cte);
                        txtComentarios.Clear();
                    }
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket cancelado");
                    }
                }
                else
                {
                    MessageBox.Show("INDICA UN NUMERO DE TICKET.");
                }
            }
            cargarTickets();
            dataGridView2.Rows.Clear();
        }

        private void actualizaSaldo(int cte)
        {
            double saldo = 0;
            saldo = obtenerSaldoCte(cte);
            saldo = saldo - sumTotal;
            updateSaldo(cte, saldo);
            Calculo cancel = new Calculo();
            cancel.borraCronograma(cte);
            cancel.calculaAbonos(saldo, cte);
        }

        private void updateSaldo(int cte, double saldo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                string query = "UPDATE clientes SET Saldo="+saldo+" WHERE ID_Cliente=" + cte + ";";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private double obtenerSaldoCte(int cte)
        {
            DataTable dt = new DataTable();
            double saldo =0;
            string query = "Select Saldo from clientes where ID_Cliente=" + cte + "";
            using (MySqlConnection conn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
                saldo = Convert.ToDouble(dt.Rows[0][0].ToString());
                return saldo;
            }
        }
        double sumTotal = 0;
        private void cancelaventas(string IDTicket, string sucid, string cajid)
        {
            int cont=0;
            foreach (DataGridViewRow dg in dataGridView2.Rows)
            {
                try
                {
                    if (Convert.ToInt32(dataGridView2.Rows[cont].Cells["Estado"].Value) == 0)
                    {
                        //dataGridView2.Rows[dg.Index].DefaultCellStyle.BackColor = Color.Bisque;
                        idVenta = Convert.ToInt32(dataGridView2.Rows[cont].Cells[0].Value);
                        idProducto = dataGridView2.Rows[cont].Cells[2].Value.ToString();
                        idSucursal = Convert.ToInt32(dataGridView2.Rows[cont].Cells[9].Value);
                        cantidad = Convert.ToInt32(dataGridView2.Rows[cont].Cells[5].Value);
                        sumTotal += Convert.ToDouble(dataGridView2.Rows[cont].Cells[7].Value);
                        cancelaProducto(idProducto, IDTicket, idVenta);
                        actualizaExistencia(idProducto, idSucursal, cantidad);
                    }
                    cont++;
                }
                catch (Exception r)
                {
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCancelarTicket.Enabled = false;
            if (Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[12].Value) == 0)
            {
                btnCancelarProd.Enabled = true;
            }
            else
            {
                btnCancelarProd.Enabled = false;
            }
            idVenta = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            idProducto = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            idSucursal = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[9].Value);
            cantidad = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[5].Value);
            subtotal = Convert.ToDouble(dataGridView2.SelectedRows[0].Cells[7].Value);
        }

        private void actualizaExistencia(string idProducto, int idSucursal, int cantidad)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                string query = "Update existencias SET existencias.Existencias = existencias.Existencias +('" + cantidad + "') WHERE existencias.ID_Producto='" + idProducto + "' AND existencias.ID_Sucursal='" + idSucursal + "';";
                
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnCancelarProd_Click(object sender, EventArgs e)
        {
            if (txtComentarios.Text == String.Empty)
            {
                MessageBox.Show("Por favor ingrese un comentario antes de cancelar");
                return;
            }
            cancelaProducto(idProducto, IDTicket, idVenta);
            actualizaExistencia(idProducto, idSucursal, cantidad);
            button1.PerformClick();
            int  cont = 0;
            //bool x = false;
            int cancelados = 0;
            int renglones = 0;
            renglones = dataGridView2.Rows.Count;
            foreach (DataGridViewRow dg in dataGridView2.Rows)
            {
                try
                {
                    if (Convert.ToInt32(dataGridView2.Rows[dg.Index].Cells["Estado"].Value) == 2)
                    {
                        cancelados++;
                    }
                    cont++;
                }
                catch (Exception r)
                {
                }
                if (cancelados == renglones)
                {
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        string query;
                        if (tipov == "CONTADO")
                        {
                            query = "Update tickets SET Estado = 2 WHERE ID_Ticket ='" + IDTicket + "';";
                        }
                        else
                        {
                            query = "Update ticketscredito SET Estado = 2 WHERE ID_TicketCredito ='" + IDTicket + "';";
                        }
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            if (tipov == "CREDITO")
            {
                double saldo = 0;
                saldo = obtenerSaldoCte(cte);
                saldo = saldo - subtotal;
                Calculo cancel = new Calculo();
                cancel.borraCronograma(cte);
                if (saldo > 0)
                {
                    updateSaldo(cte, saldo);
                    cancel.calculaAbonos(saldo, cte);
                }
                else
                {
                    updateSaldo(cte, 0);
                    cancel.calculaAbonos(0, cte);
                }
            }
            txtComentarios.Clear();
            cargarTickets();
            dataGridView2.Rows.Clear();
        }

        private void cancelaProducto(string idProducto, string IDTicket, int idVenta)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                string query;
                if (tipov == "CONTADO")
                {
                    query = "Update ventas SET Estado = 2,comentarios='"+txtComentarios.Text+"' WHERE ID_Venta ='" + idVenta + "' AND ID_Producto='" + idProducto + "';";
                }
                else
                {
                    query = "Update ventascredito SET Estado = 2,comentarios='" + txtComentarios.Text + "' WHERE ID_Venta ='" + idVenta + "' AND ID_Producto='" + idProducto + "';";
                }
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto cancelado");
                }
            }
        }
    }
}
