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
using Developers.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace Developers
{
    public partial class FrmProductos : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public string id= "";
        public bool isNew = true;
        public FrmProductos()
        {
            InitializeComponent();
        }
        static MySqlConnection NuevaConexion()
        {
            String connstring;
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            var conexion = new MySqlConnection(connstring);
            try
            {
                conexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexion! " + ex, "Error de conexion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return conexion;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtIdProducto.BackColor = System.Drawing.Color.White;
            txtIdProducto.ResetText();
            txtIdProducto.Select();
            txtDescripcion.BackColor = System.Drawing.Color.White;
            txtDescripcion.ResetText();
            //nuPrecioCosto.Value = 0;
            nuPrecioVenta.Value = 0;
            nuExistencias.Value = 0;
            //nuCantidadExistencia.Value = 0;
            
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            if (!isNew)
            {
                txtCodigo.ReadOnly = true;
                cargaDepartamentos();
                cargarProducto();
            }
            else
            {
                btnEliminar.Enabled = false;
                cargaDepartamentos();
            }
        }

        private void cargaDepartamentos()
        {
            FbConnection conectar = new FbConnection(Conectar.NuevaConexion());
            try
            {
                conectar.Open();
                //MessageBox.Show("Coneccion exitosa");
                FbDataAdapter datos = new FbDataAdapter("SELECT * FROM departamentos", conectar);
                DataTable ds = new DataTable();
                ds = new DataTable();
                datos.Fill(ds);
                cbDepartamentos.DataSource = ds;
                cbDepartamentos.DisplayMember = "nombre";
                cbDepartamentos.ValueMember = "iddepartamento";

                conectar.Close();
                //this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexion");
            }
        }

        private void cargartasas()
        {
            String connstring;
            String peTasas;
            DataTable tablatasas = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peTasas = "select Valor from tasas;";

            try
            {
                MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peTasas, conexion);
                //Rellenamos tabla   tabla.Rows[0][1].ToString();
                adaptador.Fill(tablatasas);

                conexion.Close();
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string peticion = "DELETE FROM productos WHERE IDproducto= '" + id + "';";

            try
            {
                FbConnection conexion = new FbConnection(Conectar.NuevaConexion());
                conexion.Open();
                FbCommand commando = new FbCommand(peticion, conexion);

                commando.ExecuteNonQuery();

                conexion.Close();
                //txtDepartamento.ResetText();
                //txtDepartamento.Select();
                //idenviar = 0;
                MessageBox.Show("Producto eliminado.", "Producto eliminado con exito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdministrarDepartamentos_Click(object sender, EventArgs e)
        {
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
            formulario.StartPosition = FormStartPosition.CenterScreen;
            formulario.Show();
        }
        public void cargarProducto()
        {
                String peticion = string.Empty;
                DataTable tabla = new DataTable();
            //FUNCION PARA CARGAR PRODUCTO
            try
            {
                //CARGA 
                peticion = "SELECT PRODUCTOS.IDPRODUCTO, PRODUCTOS.DESCRIPCION,  PRODUCTOS.PRECIO,  PRODUCTOS.EXISTENCIA,  PRODUCTOS.CODIGO,  PRODUCTOS.IDDEPARTAMENTO,  DEPARTAMENTOS.NOMBRE FROM PRODUCTOS  INNER JOIN DEPARTAMENTOS ON (PRODUCTOS.IDDEPARTAMENTO = DEPARTAMENTOS.IDDEPARTAMENTO) WHERE idproducto=" + id + " ;";
                //peticion = "SELECT * FROM productos INNER JOIN departamentos WHERE productos.iddepartamento = departamentos.iddepartamento and productos.codigo=" + id + " ;"; 

                using (FbConnection conexion = new FbConnection(Conectar.NuevaConexion()))
                {
                    conexion.Open();
                    FbDataAdapter adaptador = new FbDataAdapter(peticion, conexion);
                    adaptador.Fill(tabla);
                    if (tabla.Rows.Count > 0)
                    {
                        txtIdProducto.Text = tabla.Rows[0][0].ToString();
                        txtDescripcion.Text = tabla.Rows[0][1].ToString();
                        nuPrecioVenta.Value = Convert.ToInt32(tabla.Rows[0][2]);
                        nuExistencias.Value = Convert.ToInt32(tabla.Rows[0][3]);
                        cbDepartamentos.Text = tabla.Rows[0][6].ToString();
                        txtCodigo.Text = tabla.Rows[0][4].ToString();

                        //cbDepartamento.Text = tabla.Rows[0][4].ToString();
                        //nuMinimoExistencia.Value = Convert.ToInt32(tabla.Rows[0][5]);
                        //nuMaximoExistencia.Value = Convert.ToInt32(tabla.Rows[0][6]);
                        //double tas = Convert.ToDouble(tabla.Rows[0][7]);
                        //if (tas == 0)
                        //{
                        //    cbTasas.Text = "0.00";
                        //    cbTasas.Enabled = false;
                        //    rbSI.Checked = true;
                        //}
                        //else
                        //{
                        //    cbTasas.Text = tas.ToString();
                        //}
                        //cbDescuento.Text = tabla.Rows[0][8].ToString();
                    }
                    else
                    {
                        respnuevo = MessageBox.Show("Producto no encontrado, deseas agregarlo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (respnuevo == DialogResult.Yes)
                        {

                        }
                        else
                        {
                           // btnNuevo.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        public bool consultaRegistroProducto()
        {
            String connstring;
            String peticionNT;
            DataTable tabla = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticionNT = "SELECT ID_Producto FROM productos WHERE ID_Producto ="+txtIdProducto.Text;

            try
            {
                MySqlConnection conexion = new MySqlConnection(connstring);
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticionNT, conexion);


                adaptador.Fill(tabla);
                conexion.Close();
                if (tabla.Rows.Count > 0)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
            return false;
        }
        private void actualizaProducto()
        {
            //GUARDAR
            String connstring;
            String peticion,peticion2;

            {
                peticion = "UPDATE productos SET Descripcion='" + txtDescripcion.Text + "',precio='" + nuPrecioVenta.Text + "',Existencia='" + nuExistencias.Text + "',iddepartamento='" + cbDepartamentos.SelectedValue + "' WHERE IDProducto= '" + txtIdProducto.Text + "';";
                //peticion2 = "UPDATE existencias SET Descripcion='" + txtDescripcion.Text + "' WHERE ID_Producto= '" + txtIdProducto.Text + "';";
                try
                {
                    FbConnection conexion = new FbConnection(Conectar.NuevaConexion());
                    conexion.Open();
                    FbCommand commando = new FbCommand(peticion, conexion);
                    //MySqlCommand commando2 = new MySqlCommand(peticion2, conexion);
                    commando.ExecuteNonQuery();
                    //commando2.ExecuteNonQuery();
                    conexion.Close();
                    //using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
                    //{
                    //    cnn.Open();
                    //    string qry = "UPDATE existencias SET Descripcion='" + txtDescripcion.Text + "' WHERE ID_Sucursal=1 and ID_Producto='" + txtIdProducto + "';";
                    //    MySqlCommand cmd = new MySqlCommand(qry, cnn);
                    //    cmd.ExecuteNonQuery();
                    //}
                    MessageBox.Show("Producto actualizado.", "Se actualizó el producto con exito.", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //btnNuevo.PerformClick();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if (isNew==false)
            {
                actualizaProducto();
            }
            else
            {
                if (txtCodigo.Text != "")
                {
                    if (txtDescripcion.Text != "")
                    {
                        //GUARDAR PRODUCTOS
                        try
                        {
                            String peticion0 = "INSERT into productos (codigo,Descripcion,Precio,Existencia,Iddepartamento) values ('" + txtCodigo.Text + "','" + txtDescripcion.Text + "','" + nuPrecioVenta.Text + "','" + nuExistencias.Text + "','" + cbDepartamentos.SelectedValue + "');";
                            FbConnection conexion = new FbConnection(Conectar.NuevaConexion());

                            conexion.Open();
                            using (FbCommand cmd0 = new FbCommand(peticion0, conexion))
                            {
                                cmd0.ExecuteNonQuery();
                            }

                            conexion.Close();
                            MessageBox.Show("Producto guardado.", "Producto guardado con exito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error " + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingresa una descripción para el producto");
                        txtDescripcion.BackColor = System.Drawing.Color.Yellow;
                        txtDescripcion.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa el código de un producto");
                    txtCodigo.BackColor = System.Drawing.Color.Yellow;
                    txtCodigo.Focus();
                }
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            nombre.Text = txtDescripcion.Text;
        }
        private void txtIdProducto_KeyPress(object sender, KeyPressEventArgs e)
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
                //MessageBox.Show("Enter pressed", "Attention");
                //location.href = "redirectPage.aspx";
                //cargarProducto();
                //btnAgregar.PerformClick();
                //txtCodigoP.Text = "";
                //txtCantidad.Text = "1";
                //if (txtIdProducto.Text != "")
                //{
                    cargarProducto();
                //}
            }
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {
            //txtIdProducto.Select();
            //txtDescripcion.BackColor = System.Drawing.Color.White;
            //txtDescripcion.ResetText();
            //nuPrecioVenta.Value = 0;
            //nuExistencias.Value = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtIdProducto.Text != "")
            {
                cargarProducto();
            }
            else
            {
                MessageBox.Show("Ingresa un código!");
                txtIdProducto.BackColor = System.Drawing.Color.Yellow;
                txtIdProducto.Focus();
            }
        }
        public void cargardepartamentos()
        {
        //FUNCION PARA CARGAR DEPARTAMENTOS
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "select Nombre from departamentos;";

            try
            {
                MySqlConnection conexion = new MySqlConnection(connstring);
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                //Rellenamos tabla   tabla.Rows[0][1].ToString();
                adaptador.Fill(tablacat);
                
                conexion.Close();
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }

        }

        private void btnAbrirDep_Click(object sender, EventArgs e)
        {
            FrmDepartamento formulario = new FrmDepartamento();
            formulario.WindowState = FormWindowState.Normal;
            //formulario.TopMost = true;
            formulario.Show();
        }

        private void cbDepartamento_Click(object sender, EventArgs e)
        {
            //cargardepartamentos();
        }
        
        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCambiarDpto_Click(object sender, EventArgs e)
        {
            FrmCambiarDepto formulario = new FrmCambiarDepto();
            formulario.WindowState = FormWindowState.Normal;
            formulario.idproducto = Convert.ToInt32(id);
            //formulario.TopMost = true;
            formulario.ShowDialog();
        }

        
    }
}
