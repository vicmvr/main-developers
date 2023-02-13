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
    public partial class FrmModificarCantidad : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public String id = "";
        public String cantidad = "";
        public Double realExist = 0;
        public Double Precio = 0;
        public Double IVA = 0;
        public Double Descuento = 0;
        public Double Subtotal = 0;
        public Double extotal = 0;
        private String SQLIVA = "";
        private String SQLDescuento = "";
        private String SQLSubtotal = "";
        String connstring;
        String peticion, peticionT;
        DataTable tabla = new DataTable();
        public FrmModificarCantidad()
        {
            InitializeComponent(); 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInsertarVarios_Load(object sender, EventArgs e)
        {
            if (id != "")
            {
                if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
                {
                    ValorDelIVA(id);
                    cargaDatos(id);
                    cargaExistencias(id);
                }
                else
                {
                    cargaDatos(id);
                    cargaExistencias(id);
                    txtIVA.Visible = false;
                    txtDescuento.Visible = false;
                    lbliva.Visible = false;
                    lbldesc.Visible = false;
                    txtSubtotal.Location = new Point(149, 162);
                    lblsubtotal.Location = new Point(90, 165);
                }
            }
        }
        public void ValorDelIVA(string x)//BUSCA VALOR DE IVA
        {
            DataTable tIVA = new DataTable();
            string petIVA = "SELECT Impuesto,Descuento FROM productos WHERE ID_Producto =" + x + ";";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(petIVA, conexion);
                    adaptador.Fill(tIVA);
                }
                if (tIVA.Rows.Count > 0)
                {
                    IVA = Convert.ToDouble(tIVA.Rows[0][0]);
                    Descuento = Convert.ToDouble(tIVA.Rows[0][1]);
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
        private void cargaExistencias(string id)
        {
            DataTable tabla22 = new DataTable();
            string query22 = "SELECT Existencias FROM existencias WHERE ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Producto='"+id+"';";
            //MOSTRAR DATOS
            using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
            {
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query22, conexion);
                adaptador.Fill(tabla22);
                realExist = Convert.ToDouble(tabla22.Rows[0][0]) + Convert.ToDouble(cantidad);
            }
        }
        private void actualizaExistencias(string id,Double exist)
        {
            try
            {
                //ACTUALIZA
                //Variable.TipoCambio = Convert.ToDouble(txtTipoDeCambio.Text);
                String peticion = "UPDATE existencias SET Existencias='" + exist + "' WHERE ID_Producto='" + id + "' AND ID_Sucursal='" + Variable.IDSucursal + "';";
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(peticion, conexion);
                
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                realExist = exist;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void cargaDatos(String id)
        {
            if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
            {
                peticion = "SELECT ID_Producto,Descripcion,Cantidad,Precio,SubTotalIVA,SubTotalDescuento,SubTotal FROM ventas WHERE ID_Ticket='" + consultaTicketActual() + "' AND ID_Producto= '" + id + "';";
                //MOSTRAR DATOS CONTADO
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    txtCodigo.Text = tabla.Rows[0][0].ToString();
                    lblNombre.Text = tabla.Rows[0][1].ToString();

                    txtCantidad.Text = tabla.Rows[0][2].ToString();

                    txtPrecio.Text = String.Format("$ {0:0.00}", tabla.Rows[0][3]);
                    txtIVA.Text = String.Format("$ {0:0.00}", tabla.Rows[0][4]);
                    txtDescuento.Text = String.Format("$ {0:0.00}", tabla.Rows[0][5]);
                    txtSubtotal.Text = String.Format("$ {0:0.00}", tabla.Rows[0][6]);

                    Precio = Convert.ToDouble(tabla.Rows[0][3]);
                }
            }
            else
            {
                peticion = "SELECT ID_Producto,Descripcion,Cantidad,Precio,SubTotalIVA,SubTotal FROM ventascredito WHERE ID_TicketCredito='" + consultaTicketActual() + "' AND ID_Producto= '" + id + "';";
                //MOSTRAR DATOS CREDITO
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                }
                if (tabla.Rows.Count > 0)
                {
                    txtCodigo.Text = tabla.Rows[0][0].ToString();
                    lblNombre.Text = tabla.Rows[0][1].ToString();

                    txtCantidad.Text = tabla.Rows[0][2].ToString();

                    txtPrecio.Text = String.Format("$ {0:0.00}", tabla.Rows[0][3]);
                    txtIVA.Text = String.Format("$ {0:0.00}", tabla.Rows[0][4]);
                    txtSubtotal.Text = String.Format("$ {0:0.00}", tabla.Rows[0][5]);

                    Precio = Convert.ToDouble(tabla.Rows[0][3]);
                }
            }
        }

        public int consultaTicketActual()
        {
            /////CONSULTA TICKET
            String peticionNT;
            DataTable tabla = new DataTable();
            int v = 0; 
            if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
            {
                peticionNT = "SELECT ID_Ticket FROM tickets WHERE Estado = 1 AND ID_Sucursal='"+Variable.IDSucursal+"' AND ID_Caja='"+Variable.IDCaja+"'";
            }else
            {
                peticionNT = "SELECT ID_TicketCredito FROM ticketscredito WHERE Estado = 1 AND ID_Sucursal='" + Variable.IDSucursal + "' AND ID_Caja='" + Variable.IDCaja + "'";
            }
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
                    return v = Convert.ToInt32(tabla.Rows[0][0]);
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
            return v;
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToDouble(SQLSubtotal) > Variable.SaldoDisponible+extotal)&&(Variable.FormaPago=="CREDITO"))
            {
                MessageBox.Show("El total de la compra supera la cantidad: " + Variable.SaldoDisponible + extotal + " limite de credito disponible para el cliente: "+Variable.IDClienteActual+". Modifique la cantidad de productos, o cancele esta operación.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.SelectAll();
                txtCantidad.Focus();
            }
            else
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show("Debes ingresar una cantidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.Focus();
                    return;
                }
                if(Convert.ToDouble(txtCantidad.Text)>realExist)
                {
                    MessageBox.Show("La cantidad de productos no puede ser mayor a: "+ realExist+" existencias reales ", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }

                
                else
                {
                    if (Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        guardarDatos(id);
                        actualizaExistencias(id, (realExist - Convert.ToDouble(txtCantidad.Text)));
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no puede ser cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCantidad.Clear();
                        txtCantidad.Focus();
                    }
                }
            }
        }

        private void guardarDatos(string id)
        {
            ////RECALCULA IVA SUBTOTAL
            //Subtotal = Convert.ToDouble(txtCantidad.Text) * Precio;
            //IVA = Subtotal * .16;
            //ACTUALIZAR CANTIDAD
            String peticion;
            if ((Variable.FormaPago == "") || (Variable.FormaPago == "CONTADO"))
            {
                peticion = "UPDATE ventas SET Cantidad='" + txtCantidad.Text + "',SubTotalIVA='" + SQLIVA + "',SubTotalDescuento='" + SQLDescuento + "',SubTotal='" + SQLSubtotal + "' WHERE ID_Producto='" + id + "' AND ID_Ticket= '" + consultaTicketActual() + "';";
            }
            else
            {
                peticion = "UPDATE ventascredito SET Cantidad='" + txtCantidad.Text + "',SubTotalIVA='" + SQLIVA + "',SubTotal='" + SQLSubtotal + "' WHERE ID_Producto='" + id + "' AND ID_TicketCredito= '" + consultaTicketActual() + "';";
            }
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlCommand commando = new MySqlCommand(peticion, conexion);
                    commando.ExecuteNonQuery();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
            }
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
                SendKeys.Send("{TAB}");
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            //RECALCULA IVA SUBTOTAL
            if (txtCantidad.Text != "")
            {
                double cantidad = Convert.ToDouble(txtCantidad.Text);

                txtIVA.Text = String.Format("$ {0:0.00}", (Precio * IVA) * Convert.ToDouble(cantidad));
                SQLIVA =((Precio * IVA) * Convert.ToDouble(cantidad)).ToString();

                txtDescuento.Text = String.Format("$ {0:0.00}", (Precio * Descuento) * Convert.ToDouble(cantidad));
                SQLDescuento =((Precio * Descuento) * Convert.ToDouble(cantidad)).ToString();
                
                txtSubtotal.Text = String.Format("$ {0:0.00}", (Precio * Convert.ToDouble(cantidad)) - (Precio * Descuento) * Convert.ToDouble(cantidad));
                SQLSubtotal = (Precio * Convert.ToDouble(cantidad) - (Precio * Descuento) * Convert.ToDouble(cantidad)).ToString();
            }
        }
    }
}
