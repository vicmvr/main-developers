using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;

namespace Developers.Forms
{
    public partial class FrmBusquedaProductos : Form
    {
        public string idenviar="";
        public FrmBusquedaProductos()
        {
            InitializeComponent();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.SelectedRows.Count > 0)
                {
                    idenviar = dgv1.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
            catch (ConstraintException ex)
            {
                return;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text == string.Empty)
            {

            }
            else
            {
                actualizarGridconTxtNombre();
            }
        }
        private void actualizarGridconTxtNombre()
        {
            DataTable tablacat = new DataTable();

           // string peticion = "select ID_Cliente,NombreCompleto,LimiteCredito from clientes where ID_Cliente LIKE'%" + txtNombre.Text + "%' or NombreCompleto like'%" + txtNombre.Text + "%';";
            string query = "SELECT IDProducto,codigo,Descripcion,Precio,Existencia FROM productos where codigo LIKE'%" + txtNombre.Text + "%' or Descripcion like'%" + txtNombre.Text + "%';";
            try
            {
                using (FbConnection conexion = new FbConnection(Conectar.NuevaConexion()))
                {
                    conexion.Open();
                    FbDataAdapter adaptador = new FbDataAdapter(query, conexion);

                    adaptador.Fill(tablacat);
                    dgv1.DataSource = tablacat;
                }
                if (tablacat.Rows.Count > 0)
                {
                    dgv1.Columns["idproducto"].Visible = false;
                    dgv1.Columns["Codigo"].HeaderText = "Codigo";
                    dgv1.Columns["Codigo"].Width = 100;
                    dgv1.Columns["Descripcion"].HeaderText = "Descripción";
                    dgv1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["Precio"].HeaderText = "Precio";
                    dgv1.Columns["Existencia"].HeaderText = "Existencia";
                    //
                    dgv1.ClearSelection();
                    txtNombre.Focus();
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void FrmBusquedaProductos_Load(object sender, EventArgs e)
        {
            //if ((Variable.UsuarioRol == "CAJERO") || (Variable.UsuarioRol == "COBRADOR"))
            //{
            //    toolStripButton1.Visible = false;
            //}
            cargaProductos();
        }

        private void cargaProductos()
        {
            try
            {
                //CARGA
                DataTable tabla = new DataTable();
                String peticion = "SELECT idproducto,Codigo,Descripcion,Precio,Existencia FROM productos";// WHERE IDProducto='"+idenviar.ToString()+"'";

                using (FbConnection conexion = new FbConnection(Conectar.NuevaConexion()))
                {
                    conexion.Open();
                    FbDataAdapter adaptador = new FbDataAdapter(peticion, conexion);

                    adaptador.Fill(tabla);
                    dgv1.DataSource = tabla;
                    dgv1.Columns["idproducto"].Visible = false;
                    dgv1.Columns["Codigo"].HeaderText = "Codigo";
                    dgv1.Columns["Codigo"].Width = 100;
                    dgv1.Columns["Descripcion"].HeaderText = "Descripción";
                    dgv1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["Precio"].HeaderText = "Precio";
                    dgv1.Columns["Existencia"].HeaderText = "Existencia";
                }
                if (tabla.Rows.Count > 0)
                {
                    dgv1.Columns["idproducto"].Visible = false;
                    dgv1.Columns["Codigo"].HeaderText = "Codigo";
                    dgv1.Columns["Codigo"].Width = 100;
                    dgv1.Columns["Descripcion"].HeaderText = "Descripción";
                    dgv1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["Precio"].HeaderText = "Precio";
                    dgv1.Columns["Existencia"].HeaderText = "Existencia";
                    dgv1.ClearSelection();
                    txtNombre.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "FrmProductos")
                {
                    frm.Activate();
                    return;
                }
            }
            FrmProductos formulario = new FrmProductos();
            formulario.WindowState = FormWindowState.Normal;
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
            formulario.TopMost = true;
            cargaProductos();
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dataGridView1.CurrentCell != null)
                if (dgv1.SelectedRows.Count > 0)
                {
                    //Variable.idCredito = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    idenviar = dgv1.SelectedRows[0].Cells[0].Value.ToString();
                    btnEditar.PerformClick();
                }
            }
            catch (ConstraintException ex)
            {
                return;
            }
            //if (idenviar != "")
            //{
            //    FrmProductos edit = new FrmProductos();
            //    edit.id = idenviar;
            //    edit.isNew = false;
            //    edit.ShowDialog();
            //    cargaProducto();
            //    idenviar = "0";
            //}
            //else
            //{
            //    MessageBox.Show("Selecciona un cliente", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void cargaProducto()
        {
            MessageBox.Show("dddddddd");
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (idenviar != "")
            {
                FrmProductos edit = new FrmProductos();
                edit.id = idenviar;
                edit.isNew = false;
                //edit.MdiParent = this.MdiParent;
                //this.MdiParent.Enabled = false;
                //this.Enabled = false;
                edit.ShowDialog();
                cargaProductos();
                idenviar = "";
            }
            else
            {
                MessageBox.Show("Selecciona un producto", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButtonDepartamentos_Click(object sender, EventArgs e)
        {
            FrmDepartamento formulario = new FrmDepartamento();
            formulario.ShowDialog();
        }
    }
}
