using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using Developers.ApplicationProgrammingInterface.Properties;
using System.Threading;
using Developers.Forms;
using System.Timers;

namespace Developers
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private DialogResult respnuevo = new DialogResult();
        private static System.Timers.Timer aTimer;//sesion
       
        private void btnVentanaCobro_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = true;
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmClientes")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmClientes formulario = new FrmClientes();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        public void btnVentanaCobro_Click_1(object sender, EventArgs e)
        {
            venderToolStripMenuItem.PerformClick();
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
                    Variable.IDTicketActual = 0;
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            productosToolStripMenuItem.PerformClick();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }
        private void cierraSesion(string usuario)
        {
            try
            {
                String peticion = "UPDATE usuarios SET Sesion='" + 0 + "' WHERE Nombre= '" + usuario + "';";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(peticion, conexion);
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
        private void cargaExistencias(string id)
        {
            DataTable tabla22 = new DataTable();
            string query22 = "SELECT Existencias FROM existencias WHERE ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Producto='" + id + "';";
            //MOSTRAR DATOS
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query22, conexion);
                adaptador.Fill(tabla22);
                realExist = Convert.ToDouble(tabla22.Rows[0][0]);
            }
        }
        public void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = true;

            //if (Variable.CorteAbierto == 0)
            //{
            //    cargaCorteActual();
            //}
            ////if ((Variable.UsuarioRol == "ADMIN") || (Variable.UsuarioRol == "COBRADOR") || (Variable.UsuarioRol == "SUPERVISOR"))
            ////{
            ////    MessageBox.Show("Solo CAJEROS Y SUPERVISORES pueden realizar Developers.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    return;
            ////}
           
            //if ((Variable.CorteAbierto != 0) && ((Variable.UsuarioRol == "CAJERO") || (Variable.UsuarioRol == "SUPERVISOR") || (Variable.UsuarioRol == "ADMIN")))
            //{
            //    Contenedor.Visible = true;
            //    consultaTicketActual();
            //    lblTicket.Text = Variable.IDTicketActual.ToString();
            //    txtCodigoProducto.Select();
            //}
            //else
            //{
            //    MessageBox.Show("Es necesario abrir un corte para poder realizar una venta.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    abrirToolStripMenuItem.PerformClick();
            //}
        }
        private void cargaCorteActual()
        {
            try
            {
                //CARGA TIPO DE CAMBIO
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Corte FROM cortes WHERE Usuario='" + Variable.UsuarioActivo + "' AND Status='" + 0 + "'  ;";

                using (MySqlConnection cn = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    cn.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, cn);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        Variable.CorteAbierto = Convert.ToInt32(tabla.Rows[0][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmBusquedaProductos")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmBusquedaProductos formulario = new FrmBusquedaProductos();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.MdiParent = this;
            formulario.ShowDialog();
            //formulario.TopMost = true;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
        }
    
        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmSucursal")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmSucursal formulario = new FrmSucursal();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmConexion")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmConexion formulario = new FrmConexion();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;

        }

        private void tasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmTasas")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmTasas formulario = new FrmTasas();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Variable.UsuarioRol == "ADMIN") || (Variable.UsuarioRol == "CAJERO") || (Variable.UsuarioRol == "SUPERVISOR") || (Variable.UsuarioRol == "COBRADOR"))
            {
                String cajero = Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Activo.ToString();
                String pet;
                string estado = "0";//0 = abierto // 1 = cerrado
                pet = "select * from cortes where Usuario ='" + cajero + "'and Status='" + estado + "';";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataReader rdr = null;
                    MySqlCommand cmd = new MySqlCommand(pet, conexion);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Ya tiene abierto un corte.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Contenedor.Visible = false;//Borra pantalla ventas
                        foreach (Form frm in this.MdiChildren)
                        {
                            if (frm.Name == "FrmAbrirCorte")
                            {
                                frm.Activate();
                                return;
                            }
                        }
                        FrmAbrirCorte formulario = new FrmAbrirCorte();
                        formulario.MdiParent = this;
                        formulario.WindowState = FormWindowState.Normal;

                        formulario.StartPosition = FormStartPosition.CenterScreen;
                        formulario.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Solo CAJEROS Y SUPERVISORES pueden realizar Developers.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          
        }
        
        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Menus.Enabled = false;
            //Menus.Update();
            //Barra.Enabled = false;
            //Barra.Update();
            //cierraSesion(Variable.UsuarioActivo);
            //Variable.UsuarioActivo = "";
            //Variable.CorteAbierto = 0;
            //Developers.Properties.Settings.Default.Usuario_Activo="";
            //Developers.Properties.Settings.Default.Usuario_Pass="";
            //Developers.Properties.Settings.Default.Usuario_Rol = "";
            //lblBarraEstadoUsuario.Text = "Usuario: Ninguno";
            //Contenedor.Visible = false;//Borra pantalla ventas
            //foreach (Form frm in this.MdiChildren)
            //{
            //    if (frm.Name == "FrmLogin")
            //    {
            //        frm.Activate();
            //        return;
            //    }
            //}
            FrmLogin formulario = new FrmLogin();
            //formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Normal;
            formulario.Show();
            //cargaImpresora();
            TimerUsuarioActivo.Enabled = true;
        }
        private void TimerUsuarioActivo_Tick(object sender, EventArgs e)
        {
            if (Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Rol == "ADMIN")
            {
                //VENTAS///////////////////////////////////////////////
                administrarToolStripMenuItem.Enabled = true;
                venderToolStripMenuItem.Enabled = true;
                cobrarToolStripMenuItem.Enabled = true;
                finalizarVentaToolStripMenuItem.Enabled = true;
                historialDeVentasToolStripMenuItem.Enabled = true;
                busquedaDeCortesToolStripMenuItem.Enabled = true;
                //INVENTARIO///////////////////////////////////////////
                productoToolStripMenuItem.Enabled = true;
                //inventariosToolStripMenuItem.Enabled = true;
                productosToolStripMenuItem.Enabled = true;
                departamentosToolStripMenuItem.Enabled = true;
                reporteProductosToolStripMenuItem.Enabled = true;
                codigoDeBarrasToolStripMenuItem.Enabled = true;
                //CLIENTES/////////////////////////////////////////////
                //COBRANZA/////////////////////////////////////////////
                //cobranzaToolStripMenuItem.Enabled = true;
                //BoletasParaCobrarToolStripMenuItem.Enabled=true;
                //BoletasVencidasToolStripMenuItem.Enabled = true;
                //zonasToolStripMenuItem1.Enabled = true;
                //ADMINISTRACION///////////////////////////////////////
                administracionToolStripMenuItem.Enabled = true;
                cambiarUsuarioToolStripMenuItem.Enabled = true;
                tasaToolStripMenuItem.Enabled = true;
                empleadosToolStripMenuItem.Enabled = true;
                //AYUDA////////////////////////////////////////////////
                //BARRA////////////////////////////////////////////////
                btnVentanaCobro.Enabled = true;
            }
            else if (Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Rol == "SUPERVISOR")
            {
                //VENTAS///////////////////////////////////////////////
                administrarToolStripMenuItem.Enabled = true;
                venderToolStripMenuItem.Enabled = true;
                cobrarToolStripMenuItem.Enabled = true;
                finalizarVentaToolStripMenuItem.Enabled = true;
                historialDeVentasToolStripMenuItem.Enabled = true;
                busquedaDeCortesToolStripMenuItem.Enabled = true;
                //INVENTARIO///////////////////////////////////////////
                productoToolStripMenuItem.Enabled = true;
                //inventariosToolStripMenuItem.Enabled = true;
                productosToolStripMenuItem.Enabled = true;
                departamentosToolStripMenuItem.Enabled = true;
                reporteProductosToolStripMenuItem.Enabled = true;
                codigoDeBarrasToolStripMenuItem.Enabled = true;
                //CLIENTES/////////////////////////////////////////////
                //COBRANZA/////////////////////////////////////////////
                //cobranzaToolStripMenuItem.Enabled = true;
                //BoletasParaCobrarToolStripMenuItem.Enabled = true;
                //BoletasVencidasToolStripMenuItem.Enabled = true;
                //zonasToolStripMenuItem1.Enabled = true;
                //ADMINISTRACION///////////////////////////////////////
                administracionToolStripMenuItem.Enabled = true;
                cambiarUsuarioToolStripMenuItem.Enabled = true;
                tasaToolStripMenuItem.Enabled = false;
                empleadosToolStripMenuItem.Enabled = false;
                //AYUDA////////////////////////////////////////////////
                //BARRA////////////////////////////////////////////////
                btnVentanaCobro.Enabled = true;
            }
            else if (Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Rol == "CAJERO")
            {
                //VENTAS///////////////////////////////////////////////
                administrarToolStripMenuItem.Enabled = true;
                venderToolStripMenuItem.Enabled = true;
                cobrarToolStripMenuItem.Enabled = true;
                finalizarVentaToolStripMenuItem.Enabled = true;
                historialDeVentasToolStripMenuItem.Enabled = false;
                busquedaDeCortesToolStripMenuItem.Enabled = false;
                //INVENTARIO///////////////////////////////////////////
                productoToolStripMenuItem.Enabled = true;
                //inventariosToolStripMenuItem.Enabled = true;
                productosToolStripMenuItem.Enabled = true;
                departamentosToolStripMenuItem.Enabled = false;
                reporteProductosToolStripMenuItem.Enabled = false;
                codigoDeBarrasToolStripMenuItem.Enabled = false;
                generarCodigoDeBarrasCODE39ToolStripMenuItem.Enabled = false;
                //CLIENTES/////////////////////////////////////////////
                //COBRANZA/////////////////////////////////////////////
                //cobranzaToolStripMenuItem.Enabled = true;
                //BoletasParaCobrarToolStripMenuItem.Enabled = false;
                //BoletasVencidasToolStripMenuItem.Enabled = false;
                //zonasToolStripMenuItem1.Enabled = false;
                //ADMINISTRACION///////////////////////////////////////
                administracionToolStripMenuItem.Enabled = true;
                cambiarUsuarioToolStripMenuItem.Enabled = true;
                tasaToolStripMenuItem.Enabled = false;
                empleadosToolStripMenuItem.Enabled = false;
                //AYUDA////////////////////////////////////////////////
                //BARRA////////////////////////////////////////////////
                btnVentanaCobro.Enabled = true;
            }
            else if (Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Rol == "COBRADOR")
            {
                //VENTAS///////////////////////////////////////////////
                administrarToolStripMenuItem.Enabled = true;
                venderToolStripMenuItem.Enabled = true;
                cobrarToolStripMenuItem.Enabled = true;
                finalizarVentaToolStripMenuItem.Enabled = true;
                historialDeVentasToolStripMenuItem.Enabled = false;
                busquedaDeCortesToolStripMenuItem.Enabled = false;
                //INVENTARIO///////////////////////////////////////////
                productoToolStripMenuItem.Enabled = false;
                //inventariosToolStripMenuItem.Enabled = true;
                productosToolStripMenuItem.Enabled = true;
                departamentosToolStripMenuItem.Enabled = true;
                reporteProductosToolStripMenuItem.Enabled = true;
                codigoDeBarrasToolStripMenuItem.Enabled = true;
                //CLIENTES/////////////////////////////////////////////
                //COBRANZA/////////////////////////////////////////////
                //cobranzaToolStripMenuItem.Enabled = true;
                //BoletasParaCobrarToolStripMenuItem.Enabled = false;
                //BoletasVencidasToolStripMenuItem.Enabled = false;
                //zonasToolStripMenuItem1.Enabled = false;
                //ADMINISTRACION///////////////////////////////////////
                administracionToolStripMenuItem.Enabled = true;
                cambiarUsuarioToolStripMenuItem.Enabled = true;
                tasaToolStripMenuItem.Enabled = false;
                empleadosToolStripMenuItem.Enabled = false;
                //AYUDA////////////////////////////////////////////////
                //BARRA////////////////////////////////////////////////
                btnVentanaCobro.Enabled = true;
            }
            if (Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Rol == "")
            {
                //cambiarUsuarioToolStripMenuItem.PerformClick();
                //Menus.Enabled = false;
                //Menus.Update();
                //Barra.Enabled = false;
                //Barra.Update();
            }
            else
            {
                Menus.Enabled = true;
                Menus.Update();
                Barra.Enabled = true;
                Barra.Update();
                lblBarraEstadoUsuario.Text = "Usuario: " + Settings.Default.Usuario_Activo;
                /////////////////////////////////////////////////////////////
                //MANEJO DE SESION
                //// Create a timer with a ten second interval.
                //aTimer = new System.Timers.Timer();
                //sesionx = 0;
                //// Hook up the Elapsed event for the timer.
                //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

                //// Set the Interval to 2 seconds (2000 milliseconds).
                //aTimer.Interval = 10000;//300000 (5 minutos)
                //aTimer.Enabled = true;
                //string args = "";
                //args = Conexion.NuevaConexion().Replace(" ","")+Variable.IDUsuarioActivo.ToString()+";";
                ////carga checkin
                //String ruta = @"C:\Sesion\checkin.exe";
                //ProcessStartInfo p = new ProcessStartInfo(ruta, args);
                //Process.Start(p);
                ///////////////////////////////////////////////////////////////////
                TimerUsuarioActivo.Enabled = false;
                this.Visible = true;
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String cajero = Developers.ApplicationProgrammingInterface.Properties.Settings.Default.Usuario_Activo.ToString();
            String pet;
            string estado = "0";//0 = abierto // 1 = cerrado
            pet = "select * from cortes where Usuario ='" + cajero + "'and Status='" + estado + "';";
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataReader rdr = null;
                MySqlCommand cmd = new MySqlCommand(pet, conexion);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Contenedor.Visible = false;//Borra pantalla ventas
                    foreach (Form frm in this.MdiChildren)
                    {
                        if (frm.Name == "FrmCerrarCorte")
                        {
                            frm.Activate();
                            return;
                        }
                    }
                    FrmCerrarCorte formulario = new FrmCerrarCorte();
                    formulario.MdiParent = this;
                    formulario.WindowState = FormWindowState.Normal;
                    formulario.StartPosition = FormStartPosition.CenterScreen;
                    formulario.Show();
                }
                else
                {
                    MessageBox.Show("No hay corte abierto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblBarraEstadoUsuario.Text = "Usuario: " + Variable.UsuarioActivo;
            if ((Variable.UsuarioRol == "ADMIN")&&(Variable.TipoCambio==0))
            {
                Contenedor.Visible = false;//Borra pantalla ventas
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.Name == "FrmTipoDeCambio")
                    {
                        frm.Activate();
                        return;
                    }
                }
                FrmTipoDeCambio formulario = new FrmTipoDeCambio();
                formulario.WindowState = FormWindowState.Normal;
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog();
                formulario.TopMost = true;
            }
            //
            txtCodigoProducto.Focus();
            lblTipoCambio.Text = String.Format("$ {0:0.00}", Variable.TipoCambio);
        }
        private void cargaImpresora()
        {
            try
            {
                DataTable tabla = new DataTable();
                String peticion = "SELECT ImpresoraTickets FROM Impresoras WHERE idimpresoras=1";


                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);

                    if (tabla.Rows.Count > 0)
                    {
                        Variable.ImpresoraTickets = tabla.Rows[0][0].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Variable.list.Clear();
            if (Variable.xTotal == 0)
            {
                return;
            }
            int cont = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                Producto p = new Producto();
                p.ID_Producto = Convert.ToString(dgv.Rows[cont].Cells["xcod"].Value);
                p.Descripcion = Convert.ToString(dgv.Rows[cont].Cells["xdesc"].Value);
                p.cantidad = Convert.ToInt32(dgv.Rows[cont].Cells["xCant"].Value);
                p.PrecioContado = Convert.ToDouble(dgv.Rows[cont].Cells["xPrec"].Value);
                p.Descuento = Convert.ToDouble(dgv.Rows[cont].Cells["xDes"].Value);
                p.Impuesto = Convert.ToDouble(dgv.Rows[cont].Cells["xIva"].Value);
                p.ID_Existencias = Convert.ToInt32(dgv.Rows[cont].Cells["ID_EX"].Value);
                Variable.list.Add(p);
                cont++;
            }
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmCobrar")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmCobrar cobrar = new FrmCobrar();
            cobrar.total = Variable.xTotal;
            cobrar.WindowState = FormWindowState.Normal;
            cobrar.StartPosition = FormStartPosition.CenterParent;
            cobrar.ShowDialog();
            if (Variable.RegresaResetear == 1)
            {
                ResetearValores();
            }
        }

        public void ResetearValores()
        {
            dgv.Rows.Clear();
            Variable.xTotal = 0;
            Variable.xTotaliva = 0;
            Variable.xExistenciaenBD = 0;
            txtTotal.Text = "0.00";
            txtSTIVA.Text = "0.00";
            Variable.FormaPago = "";
            lblTicket.Text = Variable.IDTicketActual.ToString();
            //lblFormaPago.Text = "";
            Variable.IDClienteActual = 0;
            txtCodigoProducto.Clear();
            txtCodigoProducto.Focus();
            Variable.list.Clear();
            Variable.RegresaResetear = 0;
        }

        private bool CorteAbierto(string VarCajero)
        {
            try
            {//REVISA SI EL CAJERO ACTUAL TIENE UN CORTE ABIERTO                
                DataTable tabla = new DataTable();
                String peticion = "SELECT * FROM cortes WHERE Usuario ='" + VarCajero + "' AND Status=0";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    Variable.CorteAbierto = Convert.ToInt32(tabla.Rows[0][0]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            return false;
        }
      
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if(dataGridView1.SelectedRows.Count > 0)
        //        {
        //            ID_ProductoBorrar = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        //            Descripcion_ProductoBorrar = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        //            cantidadEnVenta = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        //            idventa = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        //        }
        //    }
        //    catch (ConstraintException ex)
        //    {
        //        return;
        //    }
        //}  
        public void incrementaExistencia(String cod,Double cant)
        {
            try
            {
                String peticion,peticion2;
                DataTable tabla = new DataTable();
                peticion = "SELECT Existencias FROM existencias WHERE ID_Producto ="+cod+" AND ID_Sucursal="+Variable.IDSucursal;
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                    incExistencias = Convert.ToDouble(tabla.Rows[0][0]) + cant;
                    peticion2 = "UPDATE Existencias SET existencias=" + incExistencias + " WHERE ID_Producto='" + cod + "' AND ID_Sucursal='" + Variable.IDSucursal + "';";
                    MySqlCommand commando = new MySqlCommand(peticion2, conexion);
                    commando.ExecuteNonQuery();
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
        private void btnBorrarArticulo_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = this.dgv.Rows.GetFirstRow(
            DataGridViewElementStates.Selected);

            if (rowToDelete > -1)
            {
                if (Variable.xTotal > 0)
                {
                    respnuevo = MessageBox.Show("Esta seguro de borrar el producto " + dgv.SelectedRows[0].Cells["xcod"].Value + " " + dgv.SelectedRows[0].Cells["xdesc"].Value + " de la venta actual?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (respnuevo == DialogResult.Yes)
                    {
                        Variable.xTotal -= Convert.ToDouble(dgv.SelectedRows[0].Cells["xsub"].Value);
                        txtTotal.Text = Variable.xTotal.ToString("c");
                        Variable.xTotaliva -= ((Convert.ToDouble(dgv.SelectedRows[0].Cells["xPrec"].Value) * Convert.ToDouble(dgv.SelectedRows[0].Cells["xIva"].Value)) * Convert.ToDouble(dgv.SelectedRows[0].Cells["xCant"].Value));
                        txtSTIVA.Text = Variable.xTotaliva.ToString("c");
                        this.dgv.Rows.RemoveAt(rowToDelete);
                        this.dgv.ClearSelection();
                    }
                }
            }
            else 
            {
                MessageBox.Show("Selecciona un producto para quitar de la lista.", "Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        } 

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmEntradas")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmEntradas formulario = new FrmEntradas();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmSalidas")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmSalidas formulario = new FrmSalidas();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }
        private void agregaext()
        {
            //agregar producto desde ventana buscar producto            
            if (Variable.FormaPago == "CONTADO")
            {
                precio = Variable.prod1.PrecioContado;
                //
                Variable.xTotaliva += (precio * Variable.prod1.Impuesto) * Variable.prod1.cantidad;
                Variable.xTotal += precio * Variable.prod1.cantidad;
                txtSTIVA.Text = Variable.xTotaliva.ToString("c");
                txtTotal.Text = Variable.xTotal.ToString("c");
            }
            else if (Variable.FormaPago == "CREDITO")
            {
                precio = Variable.prod1.PrecioCredito;
                //
                Variable.xTotaliva += (precio * Variable.prod1.Impuesto) * Variable.prod1.cantidad;
                Variable.xTotal += precio * Variable.prod1.cantidad;
                txtSTIVA.Text = Variable.xTotaliva.ToString("c");
                txtTotal.Text = Variable.xTotal.ToString("c");
            }
            dgv.Rows.Add(
                Variable.prod1.ID_Producto,
                Variable.prod1.Descripcion,
                precio,
                Variable.prod1.cantidad,
                Variable.prod1.Impuesto,
                Variable.prod1.Descuento,
                (precio * Variable.prod1.cantidad),
                Variable.xID_Existencias);

            
            //resetear variable global cantidad e id_existencias
            Variable.prod1.cantidad = 0;
            Variable.xID_Existencias = 0;
        }
        private void toolStripDepartamentos_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmDepartamento")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmDepartamento formulario = new FrmDepartamento();
            //formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        string codigo = "";
        string descripcion = "";
        double precio = 0;
        double decExistencias = 0;
        double incExistencias = 0;
        double cantidad = 1;
        double iva = 0;
        double descuento = 0;
        double subtotal = 0;
        double total = 0;
        string ID_ProductoBorrar = "";
        string Descripcion_ProductoBorrar = "";
        string cantidadEnVenta = "";
        private string idventa;
        double extotal = 0;
        string fecha_actual;
        private double realExist;
        
        public void ValorDelIVA(string x)//BUSCA VALOR DE IVA
        {
            String petIVA;
            DataTable tIVA = new DataTable();
            petIVA = "SELECT Impuesto,Descuento FROM productos WHERE ID_Producto =" + x + ";";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(petIVA, conexion);
                    adaptador.Fill(tIVA);
                }
                if (tIVA.Rows.Count > 0)
                {
                    iva = Convert.ToDouble(tIVA.Rows[0][0]);
                    descuento = Convert.ToDouble(tIVA.Rows[0][1]);
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
       
        private void cargaTipoCambio()
        {
            try
            {
                DataTable tabla = new DataTable();
                String peticion = "SELECT tipoDeCambio FROM tipodecambio WHERE fecha='" + Variable.Fecha + "';";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    Variable.TipoCambio = Convert.ToDouble(tabla.Rows[0][0]);
                    lblTipoCambio.Text = Variable.TipoCambio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        //public void actualizaGridVentas()
        //{
        //    String peticion;
        //    DataTable tablaventas = new DataTable();
        //    tablaventas.Clear();
        //    peticion = "SELECT * FROM ventas WHERE ID_Ticket='" + Variable.IDTicketActual.ToString() +"' AND ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Caja='" + Variable.IDCaja + "' ;";
                
        //    lblTicket.Text = Variable.IDTicketActual.ToString();
        //    if (Variable.FormaPago == "CREDITO")
        //    {
        //        peticion = "SELECT * FROM ventascredito WHERE ID_TicketCredito='" + Variable.IDTicketCreditoActual.ToString() + "' AND ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Caja='" + Variable.IDCaja + "' ;";
            
        //         lblTicket.Text = Variable.IDTicketCreditoActual.ToString();
        //    } 
           
        //    try
        //    {

        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //        {
        //            conexion.Open();
        //            MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
        //            adaptador.Fill(tablaventas);
        //        }
        //        double STIVA = 0;
        //        double STDesc = 0;
        //        double VTotal = 0;
        //        if (tablaventas.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < tablaventas.Rows.Count; i++)
        //            {
        //                if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
        //                {
        //                    STIVA = STIVA + Convert.ToDouble(tablaventas.Rows[i][6]);
        //                    STDesc = STDesc + Convert.ToDouble(tablaventas.Rows[i][7]);
        //                    VTotal = VTotal + Convert.ToDouble(tablaventas.Rows[i][8]);
        //                    txtSTIVA.Text = String.Format("$ {0:0.00}", STIVA);
        //                    txtTotal.Text = String.Format("$ {0:0.00}", VTotal);
        //                    total = VTotal;
        //                }
        //                if ((Variable.FormaPago != "") && (Variable.FormaPago == "CREDITO"))
        //                {
        //                    STIVA = STIVA + Convert.ToDouble(tablaventas.Rows[i][6]);
        //                    VTotal = VTotal + Convert.ToDouble(tablaventas.Rows[i][7]);
        //                    txtSTIVA.Text = String.Format("$ {0:0.00}", STIVA);
        //                    txtTotal.Text = String.Format("$ {0:0.00}", VTotal);
        //                    total = VTotal;
        //                }
        //            }
        //            Variable.VentaEnProceso = 1;
        //        }
        //        else
        //        {
        //            total = 0;
        //            STIVA = 0;
        //            STDesc = 0;
        //            VTotal = 0;
        //            txtSTIVA.Text = "$ 00.00";
        //            txtTotal.Text = "$ 00.00";
        //            Variable.VentaEnProceso = 0;
        //            Variable.NombreCliente = "NINGUNO";
        //            Variable.ApePat = "";
        //            Variable.ApeMat = "";
        //            Variable.IDClienteActual = 0;
        //            Variable.FormaPago="";
        //            ActualizaDatosCliente();
        //        }

        //            DataTable dt = new DataTable();
        //            string query = "SELECT SUM(Cantidad) AS Cantidad FROM ventas WHERE ID_Ticket='" + Variable.IDTicketActual + "' AND ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Caja='" + Variable.IDCaja + "' ;";
        //            lblTicket.Text = Variable.IDTicketActual.ToString();
        //        if (Variable.FormaPago == "CREDITO")
        //        {
        //            query = "SELECT SUM(Cantidad) AS Cantidad FROM ventascredito WHERE ID_TicketCredito='" + consultaTicketCreditoActual().ToString() + "' AND ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Caja='" + Variable.IDCaja + "' ;";
        //            lblTicket.Text = Variable.IDTicketCreditoActual.ToString();
        //        } 
        //        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //        {
        //            conexion.Open();
        //            MySqlDataAdapter adaptador2 = new MySqlDataAdapter(query, conexion);
        //            adaptador2.Fill(dt);
        //        }
        //        try
        //        {
        //            if (dt.Rows[0][0].GetType() != null)
        //            {
        //                if (Convert.ToInt32(dt.Rows[0][0]) > 1)
        //                    lblProdVentaActual.Text = dt.Rows[0][0].ToString() + " Productos en la venta actual.";
        //                if (Convert.ToInt32(dt.Rows[0][0]) == 1)
        //                    lblProdVentaActual.Text = "1 Producto en la venta actual.";
        //                btnBorrarArticulo.Enabled = true;
        //                btnCambiar.Enabled = true;
        //                btnCancelar.Enabled = true;
        //            }
        //            else
        //            {
        //                lblProdVentaActual.Text = "0 Productos en la venta actual.";
        //                btnBorrarArticulo.Enabled = false;
        //                btnCambiar.Enabled = false;
        //                btnCancelar.Enabled = false;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            lblProdVentaActual.Text = "0 Productos en la venta actual.";
        //            btnBorrarArticulo.Enabled = false;
        //            btnCambiar.Enabled = false;
        //            btnCancelar.Enabled = false;
        //        }
        //        if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
        //        {
        //            splitContainer1.SplitterDistance = 32;
        //        }
        //        else if (Variable.FormaPago == "CREDITO")
        //        {
        //            splitContainer1.SplitterDistance = 90;
        //        }
        //        dataGridView1.DataSource = tablaventas;
        //        dataGridView1.Columns["ID_Venta"].Visible = false;
        //        if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
        //        {
        //            try
        //            {
        //                dataGridView1.Columns["ID_Ticket"].Visible = false;
        //            }
        //            catch { }
        //        }
        //        if ((Variable.FormaPago != "") && (Variable.FormaPago == "CREDITO"))
        //        {
        //            try
        //            {
        //                dataGridView1.Columns["ID_TicketCredito"].Visible = false;
        //                dataGridView1.Columns["ID_Cliente"].Visible = false;
        //            }
        //            catch { }
        //        } 
        //        dataGridView1.Columns["ID_Sucursal"].Visible = false;
        //        dataGridView1.Columns["ID_Caja"].Visible = false;
        //        dataGridView1.Columns["ID_Usuario"].Visible = false;
        //        dataGridView1.Columns["ID_Producto"].HeaderText = "Código";
        //        dataGridView1.Columns["ID_Producto"].Width = 100;
        //        dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";
        //        dataGridView1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //        dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "c";
        //        //dataGridView1.Columns["Precio"].DefaultCellStyle.BackColor = Color.Bisque;
        //        dataGridView1.Columns["Precio"].Width = 65;
        //        dataGridView1.Columns["Cantidad"].DefaultCellStyle.Format = "n";
        //        //dataGridView1.Columns["Cantidad"].DefaultCellStyle.BackColor = Color.Beige;
        //        dataGridView1.Columns["Cantidad"].Width = 65;
        //        dataGridView1.Columns["SubTotalIVA"].HeaderText = "IVA";
        //        dataGridView1.Columns["SubTotalIVA"].DefaultCellStyle.Format = "n";
        //        //dataGridView1.Columns["IVA"].DefaultCellStyle.BackColor = Color.Azure;
        //        dataGridView1.Columns["SubTotalIVA"].Width = 65;
        //        if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
        //        {
        //            try
        //            {
        //                dataGridView1.Columns["SubTotalDescuento"].HeaderText = "Desc";
        //                dataGridView1.Columns["SubTotalDescuento"].DefaultCellStyle.Format = "c";
        //                dataGridView1.Columns["SubTotalDescuento"].Width = 65;
        //            }
        //            catch { }
        //        }
        //        dataGridView1.Columns["Subtotal"].DefaultCellStyle.Format = "c";
        //        //dataGridView1.Columns["Subtotal"].DefaultCellStyle.BackColor = Color.Beige;
        //        dataGridView1.Columns["Subtotal"].Width = 65;
        //        dataGridView1.ClearSelection();
        //        txtCodigoProducto.BackColor = System.Drawing.Color.White;
        //        txtCodigoProducto.Focus();
        //        txtCodigoProducto.SelectAll();
        //        lblFormaPago.Text = Variable.FormaPago;
        //    }
        //    catch (ConstraintException ex)
        //    {
        //        MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
        //    }
        //}
        public bool ConsultaProducto()
        { //CONSULTA PRODUCTO Y DECREMENTA EXISTENCIAS           
            Variable.xExistenciaenBD = 0;
            Variable.xID_Existencias = 0;
            String peticion;
            DataTable tablaProducto = new DataTable();
            peticion = "SELECT productos.ID_Producto,productos.Descripcion,productos.PrecioContado,productos.Existencias,productos.Impuesto,productos.Descuento FROM productos WHERE productos.ID_Producto='" + txtCodigoProducto.Text + "';";
            try
            {
                using (MySqlConnection conexion = Conexion.ConexionMySQL())
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tablaProducto);
                }
                if (tablaProducto.Rows.Count >= 1)
                {


                    codigo = tablaProducto.Rows[0][0].ToString();
                    descripcion = tablaProducto.Rows[0][1].ToString();
                    precio = Convert.ToDouble(tablaProducto.Rows[0][2]);
                    Variable.xExistenciaenBD = (Convert.ToInt32(tablaProducto.Rows[0][3]));
                    iva = Convert.ToDouble(tablaProducto.Rows[0][4]);
                    descuento = Convert.ToDouble(tablaProducto.Rows[0][5]);
                    //Variable.xID_Existencias = (Convert.ToInt32(tablaProducto.Rows[0][7]));

                    return true;//regresa verdadero si hay existencias
                }
                else
                {
                    return false;//regresa verdadero no hay existencias
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                return false;
            }
        }
        public bool ConsultaProductoExt()
        { //CONSULTA PRODUCTO Y DECREMENTA EXISTENCIAS           
            String peticion;
            DataTable tablaProducto = new DataTable();
            peticion = "SELECT productos.ID_Producto,productos.Descripcion,productos.PrecioContado,productos.Existencias,productos.Impuesto,productos.Descuento FROM productos WHERE productos.ID_Producto='" + Variable.xIDProductoExt + "';";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tablaProducto);
                }
                if (tablaProducto.Rows.Count >= 1)
                {


                    codigo = Variable.xIDProductoExt.ToString();
                    descripcion = tablaProducto.Rows[0][1].ToString();
                    precio = Convert.ToDouble(tablaProducto.Rows[0][2]);
                    Variable.xExistenciaenBD = (Convert.ToInt32(tablaProducto.Rows[0][3]));
                    iva = Convert.ToDouble(tablaProducto.Rows[0][4]);
                    descuento = Convert.ToDouble(tablaProducto.Rows[0][5]);
                    return true;//regresa verdadero si hay existencias
                }
                else
                {
                    return false;//regresa verdadero no hay existencias
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                return false;
            }
        }
        
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmAcercade")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmAcercade formulario = new FrmAcercade();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void sitioWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://facebook.com/SanLuisDevelopers/");
        }

        private void txtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnAdd.PerformClick();           
            }
        }
        private void impresoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmImpresora")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmImpresora formulario = new FrmImpresora();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
             respnuevo = MessageBox.Show("Se cancelaran todos los productos de la lista actual.", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
             if (respnuevo == DialogResult.Yes)
             {
                 ResetearValores();
             }
        }
        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmReporteProd")
                {
                    frm.Activate();
                    return;
                }
            }
            //FrmReporteProd formulario = new FrmReporteProd();
            //formulario.MdiParent = this;
            //formulario.StartPosition = FormStartPosition.CenterScreen;
            //formulario.Show();
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lblBarraEstadoFecha.Text = "Fecha: " + DateTime.Now.ToString();
            lblTipoCambio.Text = String.Format("$ {0:0.00}", Variable.TipoCambio);
            
            //if (Variable.VentaEnProceso == 0)
            //{
            //    Variable.Saldo = 0;
            //    Variable.SaldoDisponible = 0;
            //    Variable.totalAcumulado = 0;
            //    Variable.TiempoLimite = 0;
                
            //}
        }

        private void reporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmReporteClientes")
                {
                    frm.Activate();
                    return;
                }
            }
            //FrmReporteClientes formulario = new FrmReporteClientes();
            //formulario.MdiParent = this;
            //formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmEmpleados")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmUsuarios formulario = new FrmUsuarios();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void eAN13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmCodigoEan13")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmCodigoDeBarras formulario = new FrmCodigoDeBarras();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void codigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmCodigoDeBarras")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmCodigoDeBarras formulario = new FrmCodigoDeBarras();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void ayudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            string ayuda = Application.StartupPath + "\\Tools\\Ayuda.pdf";
            proc.StartInfo.FileName = ayuda;
            try
            {
                proc.Start();
            }
            catch
            {
                MessageBox.Show("El archivo de ayuda no fue localizado, dirijase con el administrador.", "Archivo de ayuda no encontrado!!");
            }
            //proc.Kill();
            proc.Close(); //liberamos recursos// atención: close no termina el proceso
        }
        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridView1.CurrentCell != null)
        //    {
        //        ID_ProductoBorrar = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        //        cantidadEnVenta = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        //        Descripcion_ProductoBorrar = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        //        btnCambiar.PerformClick();
        //    }
        //}

        private void historialDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmHistorialVentas")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmHistorialVentas formulario = new FrmHistorialVentas();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            historialDeVentasToolStripMenuItem.PerformClick();
        }

        //private void btnModificar_MouseHover(object sender, EventArgs e)
        //{
        //    ToolTip tp = new ToolTip();
        //    tp.IsBalloon = true;
        //    tp.ToolTipIcon = ToolTipIcon.Info;
        //    tp.ToolTipTitle = "Cambiar cantidad";
        //    tp.SetToolTip(this.btnCambiar, "Abre una ventana adicional para cambiar la cantidad de productos en la venta.");
      
        //}

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (ID_ProductoBorrar != "")
            {
                FrmModificarCantidad edit = new FrmModificarCantidad();
                edit.id = ID_ProductoBorrar;
                edit.cantidad = cantidadEnVenta;
                edit.extotal = total;
                edit.ShowDialog();
            }
            else {
                MessageBox.Show("Debe haber un producto seleccionado.", "Debe haber un producto seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //actualizaGridVentas();
        }
        private void btnProductoSinInv_Click(object sender, EventArgs e)
        {
            //foreach (Form frm in this.MdiChildren)
            //{
            //    if (frm.Name == "FrmProductoSinInv")
            //    {
            //        frm.Activate();
            //        return;
            //    }
            //}
            //FrmProductoSinInv formulario = new FrmProductoSinInv();
            //formulario.WindowState = FormWindowState.Normal;
            //formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.ShowDialog();
            //formulario.TopMost = true;
            throw new IndexOutOfRangeException();
        }

        private void pbCodigo_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmBuscarProducto")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmBuscarProducto formulario = new FrmBuscarProducto();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
            //actualizaGridVentas();
        }

        //private void btnCancelarTodo_Click(object sender, EventArgs e)
        //{
        //    respnuevo = MessageBox.Show("Estas seguro de CANCELAR TODOS LOS PRODUCTOS de la venta actual?", " CANCELAR TODO?",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (respnuevo == DialogResult.Yes)
        //    {
        //        String petCancelarTodo;

        //        petCancelarTodo = "DELETE FROM ventas WHERE ID_Ticket='" + consultaTicketActual() + "';";

        //        try
        //        {
        //            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //            {
        //                conexion.Open();
        //                MySqlCommand commando = new MySqlCommand(petCancelarTodo, conexion);
        //                commando.ExecuteNonQuery();
        //            }
        //            actualizaGridVentas();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
        //        }
        //    }
        //}

        private void claveDeRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmNumeroDeSerie")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmNumeroDeSerie formulario = new FrmNumeroDeSerie();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            cambiarUsuarioToolStripMenuItem.PerformClick();
        }


        private void tipoDeCambioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmTipoDeCambio")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmTipoDeCambio formulario = new FrmTipoDeCambio();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }
        
        private string obtenerFechaUP(int p)
        {
            string sql = "SELECT abonos.FechaAbonado FROM abonos where abonos.ID_Cliente=" + p + " AND abonos.Abono > 0 order by abonos.FechaAbonado desc limit 1";
            MySqlDataReader myReader;
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                myReader = cmd.ExecuteReader();
                try
                {
                    while (myReader.Read())
                    {
                        return myReader.GetDateTime(0).ToString();
                    }
                    myReader.Close();
                }catch(Exception e)
                {
                }
                return "Sin Pagos";
            }
        }

        private string obtenerCantidadAtrasada(int p)
        {
            try
            {
            string query = "SELECT case when abonos.Vencido = 1 then (sum(abonos.Vencido) * abonos.AbonoSemanal) - sum(abonos.Abono) end as CantidadVencida FROM abonos WHERE abonos.ID_Cliente="+p+";";
            
            MySqlDataReader myReader;
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    if (myReader.HasRows == true)
                    {
                        return myReader.GetDecimal(0).ToString("c");
                    }
                }
                myReader.Close();
            }
            }catch(Exception e)
            {
            }
            return "$0.0";
        }

        private void inventariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmInventarios")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmInventarios formulario = new FrmInventarios();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }
        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea salir del sistema?",
                       "Salir del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogo == DialogResult.OK)
            {
               // ResetearValores();
               // cierraSesion(Variable.UsuarioActivo);
            }
            else
            {
                e.Cancel = true; 
            }
        }
       
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //guardarCompraACreditoToolStripMenuItem.PerformClick();
        }
        private void btnBorrarArticulo_MouseHover(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Info;
            tp.ToolTipTitle = "Borrar producto";
            tp.SetToolTip(this.btnBorrarArticulo, "Borra el producto seleccionado.");
        }

        private void BoletasParaCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmBoletasCobrar")
                {
                    frm.Activate();
                    return;
                }
            }
            //FrmBoletasCobrar formulario = new FrmBoletasCobrar();
            //formulario.WindowState = FormWindowState.Normal;
            //formulario.StartPosition = FormStartPosition.CenterScreen;
            //formulario.MdiParent = this;
            //formulario.Show();
        }

        private void BoletasVencidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmRangoBoletasAtrasadas")
                {
                    frm.Activate();
                    return;
                }
            }
            //FrmRangoBoletasAtrasadas formulario = new FrmRangoBoletasAtrasadas();
            //formulario.WindowState = FormWindowState.Normal;
            //formulario.StartPosition = FormStartPosition.CenterScreen;
            //formulario.MdiParent = this;
            //formulario.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //foreach (Form frm in this.MdiChildren)
            //{
            //    if (frm.Name == "FrmReporteCorte")
            //    {
            //        frm.Activate();
            //        return;
            //    }
            //}
            //FrmReporteCorte formulario = new FrmReporteCorte();
            //formulario.WindowState = FormWindowState.Normal;
            //formulario.StartPosition = FormStartPosition.CenterParent;
            //formulario.MdiParent = this;
            //formulario.Show();

            //RepCortedeCaja report = new RepCortedeCaja();
            //ReportPrintTool pt = new ReportPrintTool(report);
            //pt.AutoShowParametersPanel = false;
            //pt.ShowPreviewDialog();
        }
        private void busquedaDeCortesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmBusquedaCorte")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmBusquedaCorte formulario = new FrmBusquedaCorte();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text != string.Empty)
            {
                lblTicket.Text = Variable.IDTicketActual.ToString();
                ConsultaProducto();
                //
                int sumacant = 0;
                int cont = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (txtCodigoProducto.Text == Convert.ToString(dgv.Rows[cont].Cells["xcod"].Value))
                    {
                        sumacant += Convert.ToInt32(dgv.Rows[cont].Cells["xCant"].Value);
                    }
                    cont++;
                }
                if (sumacant + 1 <= Variable.xExistenciaenBD)
                {
                    agregarProdGrid();
                }
                else
                {
                    MessageBox.Show("Producto con existencias agotadas.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingresa el código de un producto para agregar a la lista.", "Atención!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            //RESETEA CONTROLES
            txtCodigoProducto.Clear();
            txtCodigoProducto.Focus();
        }
        public int xcantidad = 1;
        private void agregarProdGrid()
        {
            dgv.Rows.Add(
                txtCodigoProducto.Text,
                descripcion,
                precio,
                xcantidad,
                iva,
                descuento,
                precio,
                Variable.xID_Existencias);
            dgv.ClearSelection();
            Variable.xTotal += precio;
            Variable.xTotaliva += precio * iva;
            txtSTIVA.Text = Variable.xTotaliva.ToString("c");
            txtTotal.Text = Variable.xTotal.ToString("c");
            Variable.xExistenciaenBD = 0;
            Variable.xID_Existencias = 0;
        }

        private void cobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCobrar.PerformClick();
        }

        private void generarCodigoDeBarrasCODE39ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmCodigoDeBarrasCODE39")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmCodigoDeBarrasCODE39 formulario = new FrmCodigoDeBarrasCODE39();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnHuella_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmCodigoDeBarrasCODE39")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmCodigoDeBarrasCODE39 formulario = new FrmCodigoDeBarrasCODE39();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            ToolTip tp = new ToolTip();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Info;
            tp.ToolTipTitle = "Agregar producto";
            tp.SetToolTip(this.btnAdd, "Agrega un producto a la lista.");
        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmUnidades")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmUnidades formulario = new FrmUnidades();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contenedor.Visible = false;//Borra pantalla ventas
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmConfiguracion")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmConfiguracion formulario = new FrmConfiguracion();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
        }



        //private static void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    crearIdentificadorSesion();
        ////}
        //public static Int64 sesionx=0;
        //private static void crearIdentificadorSesion()
        //{

            
        //    try
        //    {
        //        //Si esxite lo borramos
        //        string curFile = @"C:\\Sesion\\Sesion_" + Variable.IDUsuarioActivo + ".txt";
        //        //Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
        //        if (File.Exists(curFile))
        //        {
        //            File.Delete(curFile);
        //        }
        //        //Open the File
        //        StreamWriter sw = new StreamWriter("C:\\Sesion\\Sesion_" + Variable.IDUsuarioActivo + ".txt", true, Encoding.ASCII);

        //        //Writeout the numbers 1 to 10 on the same line.
        //        //for (x = 0; x < 10; x++)
        //        //{
        //        //    sw.Write(x);
        //        //}
        //        //DateTime dt = new DateTime();
        //        sesionx++;
        //        sw.Write(sesionx.ToString());
        //        sw.Write(Environment.NewLine);
        //        //close the file
        //        sw.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e.Message);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Sigue Activo el usuario " + sesionx.ToString());
        //    }
        //}
    }
}