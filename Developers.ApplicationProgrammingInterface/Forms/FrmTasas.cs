using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Developers
{
    public partial class FrmTasas : Form
    {
        public FrmTasas()
        {
            InitializeComponent();
        }

        private void FrmTasas_Load(object sender, EventArgs e)
        {
            actualizaGrid();  
        }
        public void actualizaGrid()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "select * from tasas;";

            try
            {
                MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peticion, conexion);
                //Rellenamos tabla
                adaptador.Fill(tablacat);
                dataGridView1.DataSource = tablacat;

                dataGridView1.Columns["ID_Tasa"].HeaderText = "ID";
                dataGridView1.Columns["ID_Tasa"].Width = 50;
                dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";
                dataGridView1.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["Valor"].HeaderText = "Valor";
                dataGridView1.Columns["Valor"].Width = 50;
                //Cerramos conexion
                conexion.Close();
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
            FrmNuevaTasa formulario = new FrmNuevaTasa();
            formulario.isNew = true;
            formulario.ShowDialog();
            actualizaGrid();            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idenviar != "")
            {
                FrmNuevaTasa edit = new FrmNuevaTasa();
                edit.id = idenviar;
                edit.descripcion = descripcion;
                edit.valor = valor;
                edit.isNew = false;
                edit.ShowDialog();
            }
            else
            {

                MessageBox.Show("Selecciona un registro.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            actualizaGrid();
        }

        public string idenviar="";
        public string descripcion;
        public string valor;


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.PerformClick();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Windows.Forms.DataGridViewCell selectedCell = dataGridView1.CurrentCell;
            if (dataGridView1.CurrentCell != null)
            {
                object selectedItem = dataGridView1[0, selectedCell.RowIndex].Value;
                int row = selectedCell.RowIndex;
                idenviar = Convert.ToString(selectedItem);
                
                object selectedItem1 = dataGridView1[1, selectedCell.RowIndex].Value;
                int row2 = selectedCell.RowIndex;
                descripcion = Convert.ToString(selectedItem1);
                
                object selectedItem2 = dataGridView1[2, selectedCell.RowIndex].Value;
                int row3 = selectedCell.RowIndex;
                valor = Convert.ToString(selectedItem2);
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (idenviar != "")
            {
                //BORRAR
                String connstring;
                String peticion;

                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                ConnectionStringsSection css = conf.ConnectionStrings;
                connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
                peticion = "DELETE FROM tasas WHERE ID_Tasa= '" + idenviar + "';";

                try
                {
                    MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                    conexion.Open();
                    MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);

                    commando.ExecuteNonQuery();

                    conexion.Close(); 
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
