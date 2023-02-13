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

namespace Developers
{
    public partial class FrmInventarios : Form
    {
        public FrmInventarios()
        {
            InitializeComponent();
        }

        private void FrmInventarios_Load(object sender, EventArgs e)
        {
            if ((Variable.UsuarioRol == "CAJERO") || (Variable.UsuarioRol == "COBRADOR"))
            {
                btnEditar.Visible = false;
            }
            //cargarSucursales();
        }

        //private void cargarSucursales()
        //{
        //    using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
        //    {
        //        cnn.Open();
        //        DataSet ds = new DataSet();
        //        MySqlDataAdapter da = new MySqlDataAdapter("SELECT ID_Sucursal,DireccionSucursal FROM sucursales", cnn);
        //        //se indica el nombre de la tabla
        //        da.Fill(ds);

        //        //cbSucursal.DataSource = ds.Tables[0].DefaultView;
        //        //se especifica el campo de la tabla
        //        //cbSucursal.DisplayMember = "DireccionSucursal";
        //        //cbSucursal.ValueMember = "ID_Sucursal";
        //    }
        //}
        int numSuc = 0;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text != string.Empty)
            {
                cargaDatos();
            }
            else
            {
                MessageBox.Show("Ingresa el código de un producto.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProducto.Focus();
            }
        }

        private void cargaDatos()
        {
            DataTable tablacat = new DataTable();
            string query = "SELECT productos.ID_Producto as ID,productos.Descripcion as Des,productos.PrecioContado as PC,productos.PrecioCredito as PCT,Existencias FROM existencias INNER join productos on existencias.ID_Producto = productos.ID_Producto WHERE (productos.Descripcion like'%" + txtProducto.Text + "%'OR productos.ID_Producto like'%" + txtProducto.Text + "%')";
            using (MySqlConnection cnn = new MySqlConnection(Conexion.NuevaConexion()))
            {
                cnn.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, cnn);

                adaptador.Fill(tablacat);
                dgv1.DataSource = tablacat;
                if (tablacat.Rows.Count > 0)
                {
                    //dgv1.Columns["productos.Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dgv1.ClearSelection();
                    dgv1.Columns["ID"].HeaderText = "ID";
                    dgv1.Columns["Des"].Width = 50;
                    dgv1.Columns["Des"].HeaderText = "DESCRIPCION";
                    dgv1.Columns["Des"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["PC"].HeaderText = "PRECIO CONTADO";
                    dgv1.Columns["PC"].Width = 100;
                    dgv1.Columns["PCT"].HeaderText = "PRECIO CREDITO";
                    dgv1.Columns["PCT"].Width = 100;
                    dgv1.Columns["Existencias"].HeaderText = "EXISTENCIAS";
                    dgv1.Columns["Existencias"].Width = 100;
                }
                else
                {
                    txtProducto.SelectAll();
                    txtProducto.Focus();
                }
            }
        }
        /*
        private void cargaDatos()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
            //toma en la sucursal
            peticion = "SELECT ID_Producto,Descripcion,Existencias FROM existencias WHERE ID_Sucursal='" + numSuc + "' AND ID_Producto like'%" + txtProducto.Text + "%' OR (Descripcion like'%" + txtProducto.Text + "%' AND ID_Sucursal='" + numSuc + "');";
            //peticion = "SELECT ID_Producto,Descripcion,Existencias FROM existencias WHERE ID_Producto like'%" + txtProducto.Text + "%' OR Descripcion like'%" + txtProducto.Text + "%' LIMIT 0,100;";
            try
            {
                MySqlConnection conexion = new MySqlConnection(connstring);
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);

                adaptador.Fill(tablacat);
                dataGridView1.DataSource = tablacat;
                if (tablacat.Rows.Count > 0)
                {

                    dataGridView1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.ClearSelection();
                }
                else
                {
                    txtProducto.SelectAll();
                    txtProducto.Focus();
                }

            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
         */
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar.PerformClick();
            }
        }
        String ID_Producto = "";
        String descripcion = "";
        String cantidad = "";
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.CurrentCell != null)
            {
                ID_Producto = dgv1.SelectedRows[0].Cells[0].Value.ToString();
                descripcion = dgv1.SelectedRows[0].Cells[1].Value.ToString();
                cantidad = dgv1.SelectedRows[0].Cells[4].Value.ToString();
                btnEditar.PerformClick();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ID_Producto != string.Empty)
            {
                FrmEdicionExistencias edit = new FrmEdicionExistencias();
                edit.id = ID_Producto;
                edit.descripcion = descripcion;
                edit.cantidad = cantidad;
                edit.idsuc = numSuc;
                edit.ShowDialog();
                cargaDatos();
                txtProducto.Clear();
                txtProducto.Focus();
            }
            else
            {
                MessageBox.Show("Selecciona un producto por favor.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dataGridView1.CurrentCell != null)
                if (dgv1.SelectedRows.Count > 0)
                {
                    ID_Producto = dgv1.SelectedRows[0].Cells[0].Value.ToString();
                    descripcion = dgv1.SelectedRows[0].Cells[1].Value.ToString();
                    cantidad = dgv1.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
            catch (ConstraintException ex)
            {
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            //if (txtProducto.Text != string.Empty)
            //{
            //    cargaDatos();
            //}
        }

        private void cbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable bds = new DataTable();
            //dgv1.DataSource = null;
        }
        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}
