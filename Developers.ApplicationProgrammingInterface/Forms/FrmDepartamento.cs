using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Developers.LayerEntities;
using Developers.BusinessLogicLayer;

namespace Developers
{
    public partial class FrmDepartamento : Form
    {
        //Creamos las instancias de la clase Eproducto y ProductoBol
        private EDepartamento _departamento;
        private readonly DepartamentoBol _departamentoBol = new DepartamentoBol();
        private DialogResult respnuevo = new DialogResult();
        int idenviar=0;
        public FrmDepartamento()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDepartamento_Load(object sender, EventArgs e)
        {
            cargardepartamentos();
        }
        private void cargardepartamentos()
        
        {
            List<EDepartamento> departamentos = _departamentoBol.Todos(Conexion.Nueva());

            if (departamentos.Count > 0)
            {

                dataGridView1.DataSource = departamentos;
                dataGridView1.Columns["iddepartamento"].HeaderText = "Id";
                dataGridView1.Columns["nombre"].HeaderText = "Nombre de departamento";
                dataGridView1.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                // cbUser.DisplayMember = "usuario";
                //cbUser.ValueMember = "idusuario";
            }
            else
                MessageBox.Show("No existe usuario registrado");
        }
            
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmEdicionDepartamento edit = new FrmEdicionDepartamento();
            edit.ShowDialog();
            cargardepartamentos();
        }
        private void ActualizaRegistro()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "UPDATE departamentos SET Nombre='" + txtDepartamento.Text + "'  WHERE ID_Departamento= '" + Convert.ToInt32(idenviar) + "';";

                try
                {
                    MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                    conexion.Open();
                    MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);

                    commando.ExecuteNonQuery();

                    conexion.Close();
                    cargardepartamentos();
                    txtDepartamento.ResetText();
                    txtDepartamento.Select();
                    idenviar = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                }
        }
        private bool ConsultaRegistro()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "SELECT * FROM departamentos WHERE Nombre='" + txtDepartamento.Text + "';";

            try
            {
                MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peticion, conexion);
                //Rellenamos tabla
                adaptador.Fill(tablacat);
                conexion.Close();
                if (tablacat.Rows.Count > 0)
                {
                    return true;
                }
                else 
                { 
                    return false; 
                }
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
                return true; 
            }
        }
        public void cargardepartamentosEX()
        {
            String connstring;
            String peticion;
            DataTable tablacat = new DataTable();

            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "select * from departamentos;";

            try
            {
                MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                conexion.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adaptador = new MySql.Data.MySqlClient.MySqlDataAdapter(peticion, conexion);
                //Rellenamos tabla
                adaptador.Fill(tablacat);
                dataGridView1.DataSource = tablacat;

                dataGridView1.Columns["ID_Departamento"].HeaderText = "ID";
                dataGridView1.Columns["Nombre"].HeaderText = "NOMBRE DE DEPARTAMENTO";
                dataGridView1.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                conexion.Close();
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("No se pudo conectar verifique conexion con el servidor " + ex);
            }

        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //REVISAR SI ALGUN PRODUCTO ESTA RELACIONADO <--PENDIENTE
            respnuevo = MessageBox.Show("Se eliminara el departamento "+txtDepartamento.Text, " ", MessageBoxButtons.YesNo);
            if (respnuevo == DialogResult.Yes)
            {
                if (idenviar != 0)
                {
                    //BORRAR
                    String connstring;
                    String peticion;

                    Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    ConnectionStringsSection css = conf.ConnectionStrings;
                    connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
                    peticion = "DELETE FROM departamentos WHERE ID_Departamento= '" + idenviar + "';";

                    try
                    {
                        MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                        conexion.Open();
                        MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);

                        commando.ExecuteNonQuery();

                        conexion.Close();
                        cargardepartamentos();
                        txtDepartamento.ResetText();
                        txtDepartamento.Select();
                        idenviar = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un departamento de la lista", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cargardepartamentos();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                idenviar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                txtDepartamento.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idenviar != 0)
            {
                FrmEdicionDepartamento edit = new FrmEdicionDepartamento();
                edit.id = idenviar;
                edit.ShowDialog();
                cargardepartamentos();
                txtDepartamento.Clear();
                idenviar = 0;
            }
            else
            {
                MessageBox.Show("Seleciona un departamento!");
            }
        }
        private void dataGridView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            cargardepartamentos();
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {           
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idenviar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            } 
            System.Windows.Forms.DataGridViewCell selectedCell = dataGridView1.CurrentCell;
            if (dataGridView1.CurrentCell != null)
            {
                txtDepartamento.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.PerformClick();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
