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
    public partial class FrmUsuarios : Form
    {
        int idenviar;
        DataTable dt = new DataTable();
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmEdicionUsuarios editar = new FrmEdicionUsuarios();
            editar.ShowDialog();
            editar.isNew = true;
            cargaUsuarios();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBuscar.PerformClick();
            }  
        }
        public void actualizaGrid()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "SELECT usuarios.ID_Usuario,usuarios.NombreCompleto,usuarios.Nombre,usuarios.Rol,sucursales.NombreComercial FROM usuarios INNER JOIN sucursales On usuarios.ID_Sucursal=sucursales.ID_Sucursal WHERE ID_Usuario LIKE'%" + txtID.Text + "%' OR NombreCompleto like'%" + txtID.Text + "%' OR Nombre like'%" + txtID.Text + "%';";

            try
            {
                MySqlConnection conexion = new MySqlConnection(connstring);
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);

                adaptador.Fill(tablacat);
                dgv1.DataSource = tablacat;
                if (tablacat.Rows.Count > 0)
                {
                    dgv1.Columns["ID_Usuario"].HeaderText = "ID";
                    dgv1.Columns["ID_Usuario"].Width = 50;
                    dgv1.Columns["NombreCompleto"].HeaderText = "NOMBRE COMPLETO";
                    dgv1.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["Nombre"].HeaderText = "NOMBRE DE USUARIO";
                    dgv1.Columns["Rol"].HeaderText = "PRIVILEGIOS";
                    dgv1.Columns["NombreComercial"].HeaderText = "SUCURSAL";
                }
                else
                {
                    MessageBox.Show("No existe el cliente");
                    txtID.Focus();
                }
                conexion.Close();

            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmEdicionUsuarios edit = new FrmEdicionUsuarios();
            edit.id = idenviar;
            edit.isNew = false;
            edit.ShowDialog();
            cargaUsuarios();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtID.Clear();
            //dgv1.DataSource = null;
            //dgv1.Rows.Clear();
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
            }
        }
        private void dgv1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            cargaUsuarios();
            txtID.Focus();
        }

        private void cargaUsuarios()
        {
            try
            {
                //CARGA
                DataTable tabla = new DataTable();
                String peticion = "SELECT usuarios.ID_Usuario,usuarios.NombreCompleto,usuarios.Nombre,usuarios.Rol FROM usuarios LIMIT 0,100";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                adaptador.Fill(tabla);
                dgv1.DataSource = tabla;
                if (tabla.Rows.Count > 0)
                {
                    dgv1.Columns["ID_Usuario"].HeaderText = "ID";
                    dgv1.Columns["ID_Usuario"].Width = 50;
                    dgv1.Columns["NombreCompleto"].HeaderText = "NOMBRE COMPLETO";
                    dgv1.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.Columns["Nombre"].HeaderText = "NOMBRE DE USUARIO";
                    dgv1.Columns["Rol"].HeaderText = "PRIVILEGIOS";
                    //dgv1.Columns["NombreComercial"].HeaderText = "SUCURSAL";
                }
                else
                {
                    MessageBox.Show("No existe el usuario");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }       
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            actualizaGrid();
            txtID.Focus();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (dataGridView1.CurrentCell != null)
                if (dgv1.SelectedRows.Count > 0)
                {
                    //Variable.idCredito = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    btnEditar.PerformClick();
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
    }
}
