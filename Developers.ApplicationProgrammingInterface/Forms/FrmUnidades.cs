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
    public partial class FrmUnidades : Form
    {
        public FrmUnidades()
        {
            InitializeComponent();
        }

        private void FrmTasas_Load(object sender, EventArgs e)
        {
            actualizaGrid();  
        }
        public void actualizaGrid()
        {
            DataTable tablacat = new DataTable();
            string peticion = "select ID_Caja,ID_Sucursal,NombreCaja,NombreSucursal from cajas;";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                {
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);
                    adaptador.Fill(tablacat);
                }
                dataGridView1.DataSource = tablacat;

                dataGridView1.Columns["ID_Caja"].HeaderText = "ID CAJA";
                dataGridView1.Columns["ID_Caja"].Width = 80;
                dataGridView1.Columns["ID_Sucursal"].HeaderText = "ID SUCURSAL";
                dataGridView1.Columns["ID_Sucursal"].Width = 110;
                dataGridView1.Columns["NombreCaja"].HeaderText = "NOMBRE DE CAJA";
                dataGridView1.Columns["NombreCaja"].Width = 140;
                dataGridView1.Columns["NombreSucursal"].HeaderText = "NOMBRE DE SUCURSAL";
                dataGridView1.Columns["NombreSucursal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaCaja formulario = new FrmNuevaCaja();
            formulario.isNew = true;
            formulario.ShowDialog();
            actualizaGrid();            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idenviar!="")
            {
                FrmNuevaCaja edit = new FrmNuevaCaja();
                edit.id = idenviar;
                edit.isNew = false;
                edit.ShowDialog();
                actualizaGrid();
            }
            else
            {
                MessageBox.Show("Selecciona una zona.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string idenviar="";
        


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.PerformClick();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DataGridViewCell selectedCell = dataGridView1.CurrentCell;
            if (dataGridView1.CurrentCell != null)
            {
                //ID
                object selectedItem0 = dataGridView1[0, selectedCell.RowIndex].Value;
                int row0 = selectedCell.RowIndex;
                idenviar = Convert.ToString(selectedItem0);                
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (idenviar != "")
            {
                string peticion = "DELETE FROM cajas WHERE ID_Caja= '" + idenviar + "';";

                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(Conexion.NuevaConexion()))
                    {
                        conexion.Open();
                        MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                        commando.ExecuteNonQuery();
                    }
                    actualizaGrid();  
                    idenviar = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
