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
    public partial class FrmEdicionDepartamento : Form
    {
        private DialogResult respnuevo = new DialogResult();
        public int id=0;
        public FrmEdicionDepartamento()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            respnuevo = MessageBox.Show("Salir sin guardar cambios?", " ", MessageBoxButtons.YesNo);
            if (respnuevo == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDepartamento_KeyUp(object sender, KeyEventArgs e)
        {
            lblDepartamento.Text = txtDepartamento.Text;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if ((id==0)&&(txtDepartamento.Text != ""))
            {
                //GUARDAR
                String connstring;
                String peticion;

                Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                ConnectionStringsSection css = conf.ConnectionStrings;
                connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

                {
                    peticion = "INSERT into departamentos (ID_Departamento,Nombre) values ('"+id.ToString()+"','" + txtDepartamento.Text + "');";

                    try
                    {
                        MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                        conexion.Open();
                        MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);
                        commando.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("Se registro correctamente el departamento!");
                        txtDepartamento.Clear();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (txtDepartamento.Text == "")
                {
                    MessageBox.Show("Ingresa un nombre de departamento");
                }
                else
                {
                    //ACTUALIZAR
                    String connstring;
                    String peticion;

                    Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    ConnectionStringsSection css = conf.ConnectionStrings;
                    connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;
                    peticion = "UPDATE departamentos SET Nombre='" + txtDepartamento.Text + "' WHERE ID_Departamento= '" + id + "';";

                    try
                    {
                        MySql.Data.MySqlClient.MySqlConnection conexion = new MySql.Data.MySqlClient.MySqlConnection(connstring);
                        conexion.Open();
                        MySql.Data.MySqlClient.MySqlCommand commando = new MySql.Data.MySqlClient.MySqlCommand(peticion, conexion);

                        commando.ExecuteNonQuery();

                        conexion.Close();
                        txtDepartamento.Clear();
                        id = 0;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo connectar verifique conexion con el servidor " + ex);
                    }
                }
            }
            txtDepartamento.Select();
        }

        private void FrmEdicionDepartamento_Load(object sender, EventArgs e)
        {
            String connstring;
            String peticion;
            DataTable tabla = new DataTable();
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection css = conf.ConnectionStrings;
            connstring = css.ConnectionStrings["Developers.Properties.Settings.ConnectionString"].ConnectionString;

            peticion = "SELECT * FROM departamentos where ID_Departamento='" + id + "';";
            //MOSTRAR DATOS
            MySqlConnection conexion = new MySqlConnection(connstring);
            conexion.Open();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(peticion, conexion);

            adaptador.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                txtDepartamento.Text = tabla.Rows[0][1].ToString();
                lblDepartamento.Text = txtDepartamento.Text;
            }
        }

        private void txtDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnNuevo.PerformClick();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
