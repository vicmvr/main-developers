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

namespace Developers
{
    public partial class FrmBuscarProducto : Form
    {
        String Vcodigo = "";
        String Vdescripcion = "";
        Double Vprecio = 0;
        Double VprecioCont = 0;
        Double VprecioCred = 0;
        double decExistencias = 0;
        double incExistencias = 0;
        double cantidad = 1;
        double iva = 0;
        double descuento = 0;
        double subtotal = 0;
        double total = 0;
        string ID_ProductoBorrar = "";
        public FrmBuscarProducto()
        {
            InitializeComponent();
        }
        private int Corte = 0;
        private string codigo="";
        private string descripcion="";
        private double precio=0;
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            buscaProducto();
        }
        private void buscaProducto()
        {
            //if (txtCodigo.Text != "")
            //{
            //    DataTable tabla = new DataTable();
            //    string query = "SELECT existencias.ID_Producto,existencias.Descripcion,productos.PrecioContado,productos.PrecioCredito,existencias.Existencias FROM existencias INNER JOIN productos ON productos.ID_Producto = existencias.ID_Producto WHERE existencias.ID_Sucursal='"+Variable.IDSucursal+"' AND (existencias.ID_Producto LIKE "+"'%" + txtCodigo.Text + "%'" + "OR existencias.Descripcion LIKE "+"'%" + txtCodigo.Text + "%')";
            //    try
            //    {
            //        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            //        {
            //            conexion.Open();
            //            MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(query, conexion);
            //            adaptador.Fill(tabla);
            //            dataGridView1.DataSource = tabla;
            //            dataGridView1.Columns["ID_Producto"].HeaderText = "Código";
            //            dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";
            //            dataGridView1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //            dataGridView1.Columns["PrecioContado"].HeaderText = "Precio Contado";
            //            dataGridView1.Columns["PrecioCredito"].HeaderText = "Precio Credito";
            //            dataGridView1.Rows[0].Selected = false;
            //        }
            //    }
            //    catch (ConstraintException ex)
            //    {
            //        MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            //    }
            //}
        } 
       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCantidad.Text = "1";
            txtCantidad.SelectAll();
            txtCantidad.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Vcodigo == string.Empty)
            {
                MessageBox.Show("Selecciona un producto.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodigo.Focus();
                return;
            }
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("Ingresa una cantidad.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.Focus();
                return;
            }
            else
            {
                if (Convert.ToDouble(txtCantidad.Text) == 0)
                {
                    MessageBox.Show("La cantidad ingresada no puede ser 0.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.Clear();
                    txtCantidad.Focus();
                    return;
                }
            }
            if ((Vcodigo != string.Empty)&&(txtCantidad.Text != ""))
            { 
                int cant = Convert.ToInt32(txtCantidad.Text);
                if (Calculo.ValidaCantidad(Vcodigo, cant) == false)
                {
                    MessageBox.Show("La cantidad ingresada supera las existencias en el inventario.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }
                ConsultaProducto();
                //crear ext prod1
                //Variable.prod1.ID_Producto = Vcodigo;
                //Variable.prod1.Descripcion = descripcion;    
                //Variable.prod1.cantidad=Convert.ToInt32(txtCantidad.Text);
                //Variable.prod1.Impuesto=iva;
                //Variable.prod1.Descuento=descuento;
                //if (Variable.FormaPago == "CONTADO")
                //{
                //    Variable.prod1.PrecioContado = precio;
                //}
                //else if (Variable.FormaPago == "CREDITO")
                //{
                //    Variable.prod1.PrecioCredito = precio;
                //}
            }
                this.Close();
        }
        //    public void agregarProducto()
        //{
        //    cantidad = Convert.ToDouble(txtCantidad.Text);
        //    //SI ConsultaExistencias ES (verdadero) MAYOR IGUAL A 1
        //    if ((ConsultaProducto() == true) && (Vcodigo != ""))
        //    {
        //        string peticion;
        //        DataTable tabla = new DataTable();
        //        if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
        //        {
        //            peticion = "INSERT into ventas (ID_Ticket,ID_Producto,Descripcion,Precio,Cantidad,SubTotalIVA,SubtotalDescuento,Subtotal,ID_Sucursal,ID_Caja,ID_Usuario) values ('" + consultaTicketActual().ToString() + "','" + Vcodigo + "','" + Vdescripcion + "','" + Vprecio + "','" + cantidad + "','" + ((Vprecio * iva) * cantidad) + "','" + ((Vprecio * descuento) * cantidad) + "','" + ((Vprecio * cantidad) - ((Vprecio * descuento) * cantidad)) + "','" + Variable.IDSucursal + "','" + Variable.IDCaja + "','" + Variable.IDUsuarioActivo + "');";
        //        }
        //        else
        //        {
        //            peticion = "INSERT into ventascredito (ID_TicketCredito,ID_Producto,Descripcion,Precio,Cantidad,SubTotalIVA,Subtotal,ID_Sucursal,ID_Caja,ID_Usuario,ID_Cliente) values ('" + consultaTicketActual().ToString() + "','" + Vcodigo + "','" + Vdescripcion + "','" + Vprecio + "','" + cantidad + "','" + ((Vprecio * iva) * cantidad) + "','" + (Vprecio * cantidad) + "','" + Variable.IDSucursal + "','" + Variable.IDCaja + "','" + Variable.IDUsuarioActivo + "','" + Variable.IDClienteActual + "');";
        //        }
        //        try
        //        {
        //            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //            {
        //                conexion.Open();
        //                MySqlCommand commando = new MySqlCommand(peticion, conexion);
        //                commando.ExecuteNonQuery();
        //            }
        //        }
        //        catch (ConstraintException ex)
        //        {
        //            MessageBox.Show("ERROR" + ex);
        //        }
        //        //////CAMBIAMOS EL STATUS EN EXISTENCIAS
        //        string peticion2 = "UPDATE existencias SET Existencias=" + decExistencias + " WHERE ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Producto='" + Vcodigo + "';";

        //        try
        //        {
        //            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
        //            {
        //                conexion.Open();
        //                MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion2, conexion);
        //                commando.ExecuteNonQuery();
        //            }
        //        }
        //        catch (ConstraintException ex)
        //        {
        //            MessageBox.Show("ERROR" + ex);
        //        }
        //        //ACTUALIZA GRID VENTAS
        //    }
        //}
        public bool ConsultaProducto()
        { //CONSULTA PRODUCTO Y DECREMENTA EXISTENCIAS           
            String peticion;
            DataTable tablaProducto = new DataTable();
            peticion = "SELECT productos.ID_Producto,productos.Descripcion,productos.PrecioContado,productos.PrecioCredito,existencias.Existencias,productos.Impuesto,productos.Descuento FROM productos,existencias WHERE productos.ID_Producto='" + Vcodigo + "' AND existencias.ID_Producto='" + Vcodigo + "'AND existencias.ID_Sucursal='" + Variable.IDSucursal + "';";
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

                    Variable.prod1.ID_Producto = tablaProducto.Rows[0][0].ToString();
                    Variable.prod1.Descripcion = tablaProducto.Rows[0][1].ToString();
                    Variable.prod1.cantidad = Convert.ToInt32(txtCantidad.Text);
                    Variable.prod1.Impuesto = Convert.ToDouble(tablaProducto.Rows[0][5]);
                    Variable.prod1.Descuento = Convert.ToDouble(tablaProducto.Rows[0][6]);
                    Variable.prod1.PrecioContado = Convert.ToDouble(tablaProducto.Rows[0][2]);
                    Variable.prod1.PrecioCredito = Convert.ToDouble(tablaProducto.Rows[0][3]);

                    Variable.xExistenciaenBD = (Convert.ToInt32(tablaProducto.Rows[0][4]));
                    //decExistencias = (Convert.ToDouble(tablaProducto.Rows[0][4]) - Convert.ToInt32(txtCantidad.Text));
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
        
 

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtCodigo.Text != "")
                {
                    DataTable tabla = new DataTable();
                    string query = "SELECT existencias.ID_Producto,existencias.Descripcion,productos.PrecioContado,productos.PrecioCredito,existencias.Existencias FROM existencias INNER JOIN productos ON productos.ID_Producto = existencias.ID_Producto WHERE existencias.ID_Sucursal='" + Variable.IDSucursal + "' AND (existencias.ID_Producto LIKE " + "'%" + txtCodigo.Text + "%'" + "OR existencias.Descripcion LIKE " + "'%" + txtCodigo.Text + "%')";
                    try
                    {
                        using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                        {
                            conexion.Open();
                            MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(query, conexion);
                            adaptador.Fill(tabla);
                            if (tabla.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = tabla;
                                dataGridView1.Columns["ID_Producto"].HeaderText = "Código";
                                dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";
                                dataGridView1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                dataGridView1.Columns["PrecioContado"].HeaderText = "Precio Contado";
                                dataGridView1.Columns["PrecioCredito"].HeaderText = "Precio Credito";
                                dataGridView1.Rows[0].Selected = false;
                            }
                        }
                    }
                    catch (ConstraintException ex)
                    {
                        MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                    }
                }
                //Vcodigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //txtCantidad.Text = "1";
                //txtCantidad.SelectAll();
                //txtCantidad.Focus();
            }
            //if (e.KeyChar == 13)
            //{
            //    SendKeys.Send("{TAB}");
            //}            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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
                btnAgregar.PerformClick();
            }  
        }

        private void FrmBuscarProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtCodigo.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DataGridViewCell selectedCell = dataGridView1.CurrentCell;
            if (dataGridView1.CurrentCell != null)
            {
                object selectedItem1 = dataGridView1[0, selectedCell.RowIndex].Value;
                int row1 = selectedCell.RowIndex;
                Vcodigo = Convert.ToString(selectedItem1);
                object selectedItem2 = dataGridView1[2, selectedCell.RowIndex].Value;
                int row2 = selectedCell.RowIndex;
                VprecioCont = Convert.ToDouble(selectedItem2);
                object selectedItem3 = dataGridView1[3, selectedCell.RowIndex].Value;
                int row3 = selectedCell.RowIndex;
                VprecioCred = Convert.ToDouble(selectedItem3);
                //txtCantidad.Text = "1";
                txtCantidad.SelectAll();
                txtCantidad.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1.Focus();
                }
                else
                {
                    txtCodigo.Focus();
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Vcodigo = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtCantidad.Text = "1";
                txtCantidad.SelectAll();
                txtCantidad.Focus();
            }
        }
    }
}
