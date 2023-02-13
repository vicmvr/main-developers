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
    public partial class FrmSucursal : Form
    {
        int idenviar=0;
        DataTable dt = new DataTable();
        public FrmSucursal()
        {
            InitializeComponent();
        }

      
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmEdicionSucursal editar = new FrmEdicionSucursal();
            editar.ShowDialog();
            editar.isNew = true;
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

            peticion = "SELECT ID_Sucursal,NombreComercial,DireccionSucursal FROM sucursales WHERE ID_Sucursal LIKE'%" + txtID.Text + "%' OR NombreComercial like'%" + txtID.Text + "%';";

            try
            {
                MySqlConnection conexion = new MySqlConnection(connstring);
                conexion.Open();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                
                adaptador.Fill(tablacat);
                dgv1.DataSource = tablacat;
                if (tablacat.Rows.Count > 0)
                        {
                            dgv1.Columns["ID_Sucursal"].HeaderText = "ID SUCURSAL";
                            dgv1.Columns["ID_Sucursal"].Width = 90;
                            dgv1.Columns["NombreComercial"].HeaderText = "NOMBRE COMERCIAL";
                            dgv1.Columns["NombreComercial"].Width = 200;
                            dgv1.Columns["DireccionSucursal"].HeaderText = "DIRECCION";
                            dgv1.Columns["DireccionSucursal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                            {
                                 MessageBox.Show("No existe el sucursal");
                            }
                conexion.Close();
             
            }
            catch (ConstraintException ex)
                    {
                        MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                    }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            txtID.Clear();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.SelectedRows.Count > 0)
                    {
                        idenviar = Convert.ToInt32(dgv1.SelectedRows[0].Cells[0].Value);
                    }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void FrmSucursal_Load(object sender, EventArgs e)
        {
            cargaSucursal();
            txtID.Focus();
        }

        private void cargaSucursal()
        {
            try
            {
                //CARGA
                DataTable tabla = new DataTable();
                String peticion = "SELECT ID_Sucursal,NombreComercial,DireccionSucursal FROM sucursales";

                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion))
                adaptador.Fill(tabla);
                dgv1.DataSource = tabla;
                if (tabla.Rows.Count > 0)
                {
                    dgv1.Columns["ID_Sucursal"].HeaderText = "ID SUCURSAL";
                    dgv1.Columns["ID_Sucursal"].Width = 90;
                    dgv1.Columns["NombreComercial"].HeaderText = "NOMBRE COMERCIAL";
                    dgv1.Columns["NombreComercial"].Width = 200;
                    dgv1.Columns["DireccionSucursal"].HeaderText = "DIRECCION";
                    dgv1.Columns["DireccionSucursal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgv1.ClearSelection();
                }
                else
                {
                    MessageBox.Show("No existe la sucursal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }       
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idenviar != 0)
            {
                FrmEdicionSucursal edit = new FrmEdicionSucursal();
                edit.id = idenviar;
                edit.isNew = false;
                edit.ShowDialog();
                cargaSucursal();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            actualizaGrid();
            txtID.Focus();
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
